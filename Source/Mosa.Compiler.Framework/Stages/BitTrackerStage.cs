﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Common;
using Mosa.Compiler.Framework.IR;
using Mosa.Compiler.Framework.Trace;
using System;
using System.Diagnostics;
using System.Text;

namespace Mosa.Compiler.Framework.Stages
{
	/// <summary>
	/// Value Numbering Stage
	/// </summary>
	public sealed class BitTrackerStage : BaseMethodCompilerStage
	{
		private const int MaxInstructions = 1024;

		private const ulong Upper32BitsSet = ~(ulong)uint.MaxValue;
		private const ulong Upper48itsSet = ~(ulong)ushort.MaxValue;
		private const ulong Upper56itsSet = ~(ulong)byte.MaxValue;

		#region Internal Value Class

		private struct Value
		{
			public bool IsEvaluated;

			public ulong MaxValue;

			public ulong MinValue;

			public ulong BitsSet;

			public ulong BitsClear;

			public bool IsRangeValueIndeterminate;

			public ulong BitsKnown { get { return BitsSet | BitsClear; } }

			public bool AreLower32BitsKnown { get { return (BitsKnown & uint.MaxValue) == uint.MaxValue; } }

			public bool AreAll64BitsKnown { get { return (BitsKnown & ulong.MaxValue) == ulong.MaxValue; } }

			public bool AreLower5BitsKnown { get { return (BitsKnown & 0b11111) == 0b11111; } }
			public bool AreLower6BitsKnown { get { return (BitsKnown & 0b111111) == 0b111111; } }

			public bool IsBitsIndeterminate { get { return BitsClear == 0 && BitsSet == 0; } }

			public bool IsIndeterminate { get { return IsRangeValueIndeterminate && IsBitsIndeterminate; } }

			public void SetIndeterminate()
			{
				IsRangeValueIndeterminate = true;
				BitsSet = 0;
				BitsClear = 0;
				IsEvaluated = true;
			}

			public Value(ulong value)
			{
				MaxValue = value;
				MinValue = value;
				BitsSet = value;
				BitsClear = ~value;
				IsEvaluated = true;
				IsRangeValueIndeterminate = true;
			}

			public override string ToString()
			{
				if (!IsEvaluated)
					return "Not Evaluated";

				var sb = new StringBuilder();

				if (!IsRangeValueIndeterminate)
				{
					sb.Append($" MaxValue: {MaxValue.ToString()}");
					sb.Append($" MinValue: {MinValue.ToString()}");
				}

				if (BitsKnown != 0)
				{
					sb.Append($" BitsSet: {Convert.ToString((long)BitsSet, 2).PadLeft(64, '0')}");
					sb.Append($" BitsClear: {Convert.ToString((long)BitsClear, 2).PadLeft(64, '0')}");
					sb.Append($" BitsKnown: {Convert.ToString((long)BitsKnown, 2).PadLeft(64, '0')}");
				}

				return sb.ToString();
			}
		}

		#endregion Internal Value Class

		private Value[] Values;

		private TraceLog trace;

		private Counter InstructionUpdateCount = new Counter("BitTrackerStage.InstructionUpdate");

		private delegate void NodeVisitationDelegate(InstructionNode node);

		private NodeVisitationDelegate[] visitation = new NodeVisitationDelegate[MaxInstructions];

		protected override void Initialize()
		{
			visitation = new NodeVisitationDelegate[MaxInstructions];

			Register(InstructionUpdateCount);

			Register(IRInstruction.Phi, Phi);

			Register(IRInstruction.MoveInt32, MoveInt32);
			Register(IRInstruction.MoveInt64, MoveInt64);

			Register(IRInstruction.Truncation64x32, Truncation64x32);

			Register(IRInstruction.GetLow64, GetLow64);
			Register(IRInstruction.GetHigh64, GetHigh64);
			Register(IRInstruction.To64, To64);

			Register(IRInstruction.LogicalOr32, LogicalOr32);
			Register(IRInstruction.LogicalOr64, LogicalOr64);
			Register(IRInstruction.LogicalAnd32, LogicalAnd32);
			Register(IRInstruction.LogicalAnd64, LogicalAnd64);
			Register(IRInstruction.LogicalXor32, LogicalXor32);
			Register(IRInstruction.LogicalXor64, LogicalXor64);

			Register(IRInstruction.LoadZeroExtend8x32, LoadZeroExtend8x32);
			Register(IRInstruction.LoadZeroExtend16x32, LoadZeroExtend16x32);

			Register(IRInstruction.LoadParamZeroExtend8x32, LoadParamZeroExtend8x32);
			Register(IRInstruction.LoadParamZeroExtend16x32, LoadParamZeroExtend16x32);

			Register(IRInstruction.ShiftRight32, ShiftRight32);
			Register(IRInstruction.ShiftRight64, ShiftRight64);

			Register(IRInstruction.ShiftLeft32, ShiftLeft32);
			Register(IRInstruction.ShiftLeft64, ShiftLeft64);

			Register(IRInstruction.CompareInt32x32, CompareInt32x32);

			Register(IRInstruction.MulUnsigned32, MulUnsigned32);
			Register(IRInstruction.MulUnsigned64, MulUnsigned64);
			Register(IRInstruction.Add32, Add32);
			Register(IRInstruction.Add64, Add64);

			Register(IRInstruction.SignExtend16x32, SignExtend16x32);
			Register(IRInstruction.SignExtend8x32, SignExtend8x32);
		}

		private void Register(BaseInstruction instruction, NodeVisitationDelegate method)
		{
			visitation[instruction.ID] = method;
		}

		protected override void Run()
		{
			if (HasProtectedRegions)
				return;

			// Method is empty - must be a plugged method
			if (BasicBlocks.HeadBlocks.Count != 1)
				return;

			if (BasicBlocks.PrologueBlock == null)
				return;

			trace = CreateTraceLog(5);

			Values = new Value[MethodCompiler.VirtualRegisters.Count + 1];  // 0 entry is not used

			EvaluateVirtualRegisters();

			DumpValues();

			UpdateInstructions();
		}

		private void DumpValues()
		{
			var valueTrace = CreateTraceLog("Values", 5);

			if (valueTrace == null)
				return;

			int count = MethodCompiler.VirtualRegisters.Count;

			for (int i = 0; i < count; i++)
			{
				var virtualRegister = MethodCompiler.VirtualRegisters[i];
				var value = Values[virtualRegister.Index];

				if (value.IsIndeterminate || !value.IsEvaluated)
					continue;

				//valueTrace?.Log($"Register: {MethodCompiler.VirtualRegisters[i].ToString()}");
				valueTrace?.Log($"Node: {virtualRegister.Definitions[0].ToString()}");

				if (!value.IsRangeValueIndeterminate)
				{
					valueTrace?.Log($"  MaxValue:  {value.MaxValue.ToString()}");
					valueTrace?.Log($"  MinValue:  {value.MinValue.ToString()}");
				}

				if (value.BitsKnown != 0)
				{
					valueTrace?.Log($"  BitsSet:   {Convert.ToString((long)value.BitsSet, 2).PadLeft(64, '0')}");
					valueTrace?.Log($"  BitsClear: {Convert.ToString((long)value.BitsClear, 2).PadLeft(64, '0')}");
					valueTrace?.Log($"  BitsKnown: {Convert.ToString((long)value.BitsKnown, 2).PadLeft(64, '0')}");
				}

				valueTrace?.Log();
			}
		}

		private void EvaluateVirtualRegisters()
		{
			int count = MethodCompiler.VirtualRegisters.Count;
			int evaluated = 0;

			while (evaluated != count)
			{
				int startedAt = evaluated;

				for (int i = 0; i < count; i++)
				{
					if (Evaluate(MethodCompiler.VirtualRegisters[i]))
					{
						evaluated++;

						if (evaluated == count)
							return;
					}
				}

				// cycle detected - exit
				if (startedAt == evaluated)
					return;
			}
		}

		private bool Evaluate(Operand virtualRegister)
		{
			int index = virtualRegister.Index;

			if (Values[index].IsEvaluated)
				return false;

			if (virtualRegister.Uses.Count == 0 || virtualRegister.IsR || virtualRegister.Definitions.Count != 1 || virtualRegister.Definitions.Count == 0)
			{
				Values[index].SetIndeterminate();
				return true;
			}

			var node = virtualRegister.Definitions[0];

			// check dependencies
			foreach (var operand in node.Operands)
			{
				if (operand.IsVirtualRegister)
				{
					var operandValue = Values[operand.Index];

					if (operandValue.IsEvaluated)
						continue;

					return false; // can not evaluate yet
				}

				if (operand.IsResolvedConstant && operand.IsInteger)
					continue;

				// everything else we assume is indeterminate
				Values[index].SetIndeterminate();

				return true;
			}

			visitation[node.Instruction.ID]?.Invoke(node);

			return true;
		}

		protected override void Finish()
		{
			Values = null;
			trace = null;
		}

		private void UpdateInstructions()
		{
			int count = MethodCompiler.VirtualRegisters.Count;

			for (int i = 0; i < count; i++)
			{
				UpdateInstruction(MethodCompiler.VirtualRegisters[i]);
			}
		}

		private void UpdateInstruction(Operand virtualRegsiter)
		{
			var value = Values[virtualRegsiter.Index];

			if (value.IsIndeterminate || !value.IsEvaluated)
				return;

			Debug.Assert(!virtualRegsiter.IsR);
			Debug.Assert(virtualRegsiter.Definitions.Count == 1);

			var node = virtualRegsiter.Definitions[0];

			ulong replaceValue;

			if (virtualRegsiter.Is64BitInteger)
			{
				if (!value.IsRangeValueIndeterminate && value.MaxValue == value.MinValue)
				{
					replaceValue = value.MaxValue;
				}
				else if ((value.BitsSet | value.BitsClear) == ulong.MaxValue)
				{
					replaceValue = value.BitsSet;
				}
				else
				{
					return;
				}
			}
			else
			{
				if (!value.IsRangeValueIndeterminate && (value.MaxValue & uint.MaxValue) == (value.MinValue & uint.MaxValue))
				{
					replaceValue = value.MaxValue & uint.MaxValue;
				}
				else if (((value.BitsSet | value.BitsClear) & uint.MaxValue) == uint.MaxValue)
				{
					replaceValue = value.BitsSet & uint.MaxValue;
				}
				else
				{
					return;
				}
			}

			var instruction = virtualRegsiter.Is64BitInteger ? (BaseInstruction)IRInstruction.MoveInt64 : IRInstruction.MoveInt32;

			if (node.Instruction == instruction && node.Operand1.ConstantUnsignedLongInteger == replaceValue)
				return;

			trace?.Log($"BEFORE:\t{node}");
			node.SetInstruction(instruction, virtualRegsiter, CreateConstant(node.Result.Type, replaceValue));
			trace?.Log($"AFTER: \t{node}");

			//Debug.WriteLine(Method.FullName);

			InstructionUpdateCount++;
		}

		#region Helpers

		private static bool IsAddOverflow(ulong a, ulong b)
		{
			return ((b > 0) && (a > (ulong.MaxValue - b)));
		}

		private static bool IsAddOverflow(uint a, uint b)
		{
			return ((b > 0) && (a > (uint.MaxValue - b)));
		}

		private static bool IsMultiplyOverflow(uint a, uint b)
		{
			var r = (ulong)a * (ulong)b;

			return r > uint.MaxValue;
		}

		private static bool IsMultiplyOverflow(ulong a, ulong b)
		{
			if (a == 0 | b == 0)
				return false;

			var r = a * b;
			var r2 = r / b;

			return r2 == a;
		}

		#endregion Helpers

		private void MoveInt64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];

			var index = node.Result.Index;

			if (value1.AreAll64BitsKnown)
			{
				Values[index] = new Value(value1.MaxValue & ulong.MaxValue);
				return;
			}

			Values[index] = new Value()
			{
				MaxValue = value1.MaxValue,
				MinValue = value1.MinValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
				BitsSet = value1.BitsSet,
				BitsClear = value1.BitsClear,
				IsEvaluated = true
			};
		}

		private void MoveInt32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];

			var index = node.Result.Index;

			if (value1.AreLower32BitsKnown)
			{
				Values[index] = new Value(value1.MaxValue & uint.MaxValue);
				return;
			}

			Values[index] = new Value()
			{
				MaxValue = value1.MaxValue & uint.MaxValue,
				MinValue = value1.MinValue & uint.MaxValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
				BitsSet = value1.BitsSet & uint.MaxValue,
				BitsClear = value1.BitsClear | Upper32BitsSet,
				IsEvaluated = true
			};
		}

		private void Phi(InstructionNode node)
		{
			Debug.Assert(node.OperandCount != 0);

			var value = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];

			for (int i = 1; i < node.OperandCount; i++)
			{
				var operand = node.GetOperand(i);
				var value2 = operand.IsConstant ? new Value(operand.ConstantUnsignedLongInteger) : Values[operand.Index];

				value.MaxValue = Math.Max(value.MaxValue, value2.MaxValue);
				value.MinValue = Math.Min(value.MinValue, value2.MinValue);
				value.IsRangeValueIndeterminate = value.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate;
				value.BitsSet = value.BitsSet & value2.BitsSet;
				value.BitsClear = value.BitsClear & value2.BitsClear;
			}

			value.IsEvaluated = true;

			if (!node.Result.Is64BitInteger)
			{
				value.MaxValue = value.MaxValue & uint.MaxValue;
				value.MinValue = value.MinValue & uint.MaxValue;
				value.BitsSet = value.BitsSet & uint.MaxValue;
				value.BitsClear = value.BitsClear | Upper32BitsSet;
			}

			var index = node.Result.Index;

			Values[index] = value;
		}

		private void Truncation64x32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];

			Values[node.Result.Index] = new Value()
			{
				MaxValue = value1.MaxValue & uint.MaxValue,
				MinValue = value1.MinValue & uint.MaxValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
				BitsSet = value1.BitsSet & uint.MaxValue,
				BitsClear = value1.BitsClear | Upper32BitsSet,
				IsEvaluated = true
			};
		}

		private void GetLow64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];

			Values[node.Result.Index] = new Value()
			{
				MaxValue = value1.MaxValue & uint.MaxValue,
				MinValue = value1.MinValue & uint.MaxValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
				BitsSet = value1.BitsSet & uint.MaxValue,
				BitsClear = value1.BitsClear | Upper32BitsSet,
				IsEvaluated = true
			};
		}

		private void GetHigh64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];

			Values[node.Result.Index] = new Value()
			{
				MaxValue = (value1.MaxValue >> 32) & uint.MaxValue,
				MinValue = (value1.MinValue >> 32) & uint.MaxValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
				BitsSet = (value1.BitsSet >> 32) & uint.MaxValue,
				BitsClear = (value1.BitsClear >> 32) | Upper32BitsSet,
				IsEvaluated = true
			};
		}

		private void To64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			Values[node.Result.Index] = new Value()
			{
				MaxValue = (value2.MaxValue << 32) | (value1.MaxValue & uint.MaxValue),
				MinValue = (value2.MinValue << 32) | (value1.MinValue & uint.MaxValue),
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate,
				BitsSet = (value2.BitsSet << 32) | (value1.BitsSet & uint.MaxValue),
				BitsClear = (value2.BitsClear << 32) | (value1.BitsClear & uint.MaxValue),
				IsEvaluated = true
			};
		}

		private void ShiftRight64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			var index = node.Result.Index;

			if (value1.AreAll64BitsKnown && value2.AreLower6BitsKnown)
			{
				Values[index] = new Value(value1.MaxValue >> (int)(value2.MaxValue & 0b111111));
				return;
			}

			if (value1.AreAll64BitsKnown && value1.MaxValue == 0)
			{
				Values[index] = new Value(0);
				return;
			}

			if (value2.AreLower6BitsKnown)
			{
				var shift = (int)(value2.MaxValue & 0b111111);

				if (shift == 0)
				{
					Values[index] = value1;
					return;
				}
				Values[index] = new Value()
				{
					MaxValue = value1.MaxValue >> shift,
					MinValue = value1.MinValue >> shift,
					IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
					BitsSet = value1.BitsSet >> shift,
					BitsClear = value1.BitsClear >> shift | ~(ulong.MaxValue >> shift),
					IsEvaluated = true
				};
				return;
			}

			Values[index].SetIndeterminate();
		}

		private void ShiftRight32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			var index = node.Result.Index;

			if (value1.AreLower32BitsKnown && value2.AreLower5BitsKnown)
			{
				Values[index] = new Value((value1.MaxValue & uint.MaxValue) >> (int)(value2.MaxValue & 0b11111));
				return;
			}

			if (value1.AreLower32BitsKnown && (value1.MaxValue & uint.MaxValue) == 0)
			{
				Values[index] = new Value(0);
				return;
			}

			if (value2.AreLower5BitsKnown)
			{
				var shift = (int)(value2.MaxValue & 0b11111);

				if (shift == 0)
				{
					Values[index] = value1;
					return;
				}

				Values[index] = new Value()
				{
					MaxValue = value1.MaxValue >> shift,
					MinValue = value1.MinValue >> shift,
					IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
					BitsSet = value1.BitsSet >> shift,
					BitsClear = (value1.BitsClear >> shift) | (ulong)(~(uint.MaxValue >> shift)) | Upper32BitsSet,
					IsEvaluated = true
				};
				return;
			}

			Values[index].SetIndeterminate();
		}

		private void ShiftLeft64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			var index = node.Result.Index;

			if (value1.AreAll64BitsKnown && value2.AreLower6BitsKnown)
			{
				Values[index] = new Value((value1.MaxValue & uint.MaxValue) << (int)(value2.MaxValue & 0b111111));
				return;
			}

			if (value1.AreAll64BitsKnown && value1.MaxValue == 0)
			{
				Values[index] = new Value(0);
				return;
			}

			if (value2.AreLower6BitsKnown)
			{
				var shift = (int)(value2.MaxValue & 0b111111);

				if (shift == 0)
				{
					Values[index] = value1;
					return;
				}

				Values[index] = new Value()
				{
					MaxValue = value1.MaxValue << shift,
					MinValue = value1.MinValue << shift,
					IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
					BitsSet = value1.BitsSet << shift,
					BitsClear = (value1.BitsClear << shift) | ~(ulong.MaxValue << shift),
					IsEvaluated = true
				};

				return;
			}

			Values[index].SetIndeterminate();
		}

		private void ShiftLeft32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			var index = node.Result.Index;

			if (value1.AreLower32BitsKnown && value2.AreLower5BitsKnown)
			{
				Values[index] = new Value((value1.MaxValue & uint.MaxValue) << (int)(value2.MaxValue & 0b11111));
				return;
			}

			if (value1.AreLower32BitsKnown && (value1.MaxValue & uint.MaxValue) == 0)
			{
				Values[index] = new Value(0);
				return;
			}

			if (value2.AreLower5BitsKnown)
			{
				var shift = (int)(value2.MaxValue & 0b11111);

				if (shift == 0)
				{
					Values[index] = value1;
					return;
				}

				Values[index] = new Value()
				{
					MaxValue = value1.MaxValue << shift,
					MinValue = value1.MinValue << shift,
					IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
					BitsSet = value1.BitsSet << shift,
					BitsClear = value1.BitsClear << shift | ~(ulong.MaxValue << shift) | Upper32BitsSet,
					IsEvaluated = true
				};
				return;
			}

			Values[index].SetIndeterminate();
		}

		private void LogicalOr32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			Values[node.Result.Index] = new Value()
			{
				MaxValue = (value1.MaxValue | value2.MaxValue) & uint.MaxValue,
				MinValue = (value1.MinValue | value2.MinValue) & uint.MaxValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate,
				BitsSet = (value1.BitsSet | value2.BitsSet) & uint.MaxValue,
				BitsClear = (value2.BitsClear & value1.BitsClear) & uint.MaxValue,
				IsEvaluated = true
			};
		}

		private void LogicalOr64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			Values[node.Result.Index] = new Value()
			{
				MaxValue = value1.MaxValue | value2.MaxValue,
				MinValue = value1.MinValue | value2.MinValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate,
				BitsSet = value1.BitsSet | value2.BitsSet,
				BitsClear = value2.BitsClear & value1.BitsClear,
				IsEvaluated = true
			};
		}

		private void LogicalAnd32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			Values[node.Result.Index] = new Value()
			{
				MaxValue = (value1.MaxValue & value2.MaxValue) & uint.MaxValue,
				MinValue = (value1.MinValue & value2.MinValue) & uint.MaxValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate,
				BitsSet = (value1.BitsSet & value2.BitsSet) & uint.MaxValue,
				BitsClear = (value2.BitsClear | value1.BitsClear) & uint.MaxValue,
				IsEvaluated = true
			};
		}

		private void LogicalAnd64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			Values[node.Result.Index] = new Value()
			{
				MaxValue = value1.MaxValue & value2.MaxValue,
				MinValue = value1.MinValue & value2.MinValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate,
				BitsSet = value1.BitsSet & value2.BitsSet,
				BitsClear = value2.BitsClear | value1.BitsClear,
				IsEvaluated = true
			};
		}

		private void LogicalXor32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			ulong bitsKnown = value1.BitsKnown & value2.BitsKnown & uint.MaxValue;

			Values[node.Result.Index] = new Value()
			{
				MaxValue = 0,
				MinValue = 0,
				IsRangeValueIndeterminate = true,
				BitsSet = (value1.BitsSet ^ value2.BitsSet) & bitsKnown,
				BitsClear = (value2.BitsClear ^ value1.BitsClear) & bitsKnown,
				IsEvaluated = true
			};
		}

		private void LogicalXor64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			ulong bitsKnown = value1.BitsKnown & value2.BitsKnown;

			Values[node.Result.Index] = new Value()
			{
				MaxValue = 0,
				MinValue = 0,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate,
				BitsSet = (value1.BitsSet ^ value2.BitsSet) & bitsKnown,
				BitsClear = (value2.BitsClear ^ value1.BitsClear) & bitsKnown,
				IsEvaluated = true
			};
		}

		private void LoadZeroExtend8x32(InstructionNode node)
		{
			Values[node.Result.Index] = new Value()
			{
				MaxValue = byte.MaxValue,
				MinValue = 0,
				IsRangeValueIndeterminate = false,
				BitsSet = 0,
				BitsClear = ~(ulong)(byte.MaxValue),
				IsEvaluated = true,
			};
		}

		private void LoadZeroExtend16x32(InstructionNode node)
		{
			Values[node.Result.Index] = new Value()
			{
				MaxValue = ushort.MaxValue,
				MinValue = 0,
				IsRangeValueIndeterminate = false,
				BitsSet = 0,
				BitsClear = ~(ulong)(ushort.MaxValue),
				IsEvaluated = true
			};
		}

		private void LoadParamZeroExtend8x32(InstructionNode node)
		{
			Values[node.Result.Index] = new Value()
			{
				MaxValue = byte.MaxValue,
				MinValue = 0,
				IsRangeValueIndeterminate = false,
				BitsSet = 0,
				BitsClear = ~(ulong)(byte.MaxValue),
				IsEvaluated = true
			};
		}

		private void LoadParamZeroExtend16x32(InstructionNode node)
		{
			Values[node.Result.Index] = new Value()
			{
				MaxValue = ushort.MaxValue,
				MinValue = 0,
				IsRangeValueIndeterminate = false,
				BitsSet = 0,
				BitsClear = ~(ulong)(ushort.MaxValue),
				IsEvaluated = true
			};
		}

		private void CompareInt32x32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			var conditionCode = node.ConditionCode;

			bool hasResult = false;
			bool result = false;

			ulong maxValue1 = value1.MaxValue & uint.MaxValue;
			ulong maxValue2 = value2.MaxValue & uint.MaxValue;
			ulong minValue1 = value1.MinValue & uint.MaxValue;
			ulong minValue2 = value2.MinValue & uint.MaxValue;

			ulong bitsSet1 = value1.BitsSet & uint.MaxValue;
			ulong bitsSet2 = value2.BitsSet & uint.MaxValue;

			ulong bitsClear1 = value1.BitsClear & uint.MaxValue;
			ulong bitsClear2 = value2.BitsClear & uint.MaxValue;

			if (conditionCode == ConditionCode.Equal)
			{
				if (value1.AreLower32BitsKnown && value2.AreLower32BitsKnown)
				{
					hasResult = true;
					result = maxValue1 == maxValue2;
				}

				// if MaxValue(s) == MinValues(s) and nothing is indeterminate, then must be equal
				else if (!value1.IsRangeValueIndeterminate && !value2.IsRangeValueIndeterminate && maxValue1 == minValue1 && maxValue1 == maxValue2 && minValue1 == minValue2)
				{
					hasResult = true;
					result = true;
				}

				// if one bit doesn't match, then can not be equal (regardless of the other bits)
				else if ((((bitsSet1 & bitsSet2) != bitsSet1) || ((bitsClear1 & bitsClear2) != bitsClear1)) && value1.IsBitsIndeterminate && value2.IsBitsIndeterminate)
				{
					hasResult = true;
					result = false;
				}
			}
			else if (conditionCode == ConditionCode.NotEqual)
			{
				if (value1.AreLower32BitsKnown && value2.AreLower32BitsKnown)
				{
					hasResult = true;
					result = maxValue1 != maxValue2;
				}
				else if (!value1.IsRangeValueIndeterminate && !value2.IsRangeValueIndeterminate && maxValue1 == minValue1 && maxValue1 == maxValue2 && minValue1 == minValue2)
				{
					hasResult = true;
					result = false;
				}
				else if (value1.AreLower32BitsKnown && maxValue1 == 0 && bitsSet2 != 0)
				{
					hasResult = true;
					result = true;
				}
				else if (value2.AreLower32BitsKnown && maxValue2 == 0 && bitsSet1 != 0)
				{
					hasResult = true;
					result = true;
				}
			}
			else if (conditionCode == ConditionCode.UnsignedGreaterThan)
			{
				if (value1.AreLower32BitsKnown && value2.AreLower32BitsKnown)
				{
					hasResult = true;
					result = maxValue1 > maxValue2;
				}
				else if (value2.AreLower32BitsKnown && maxValue2 == 0 && bitsSet1 != 0)
				{
					hasResult = true;
					result = true;
				}
			}
			else if (conditionCode == ConditionCode.UnsignedLessThan)
			{
				if (value1.AreLower32BitsKnown && value2.AreLower32BitsKnown)
				{
					hasResult = true;
					result = maxValue1 < maxValue2;
				}
				else if (value1.AreLower32BitsKnown && maxValue1 == 0 && bitsSet2 != 0)
				{
					hasResult = true;
					result = true;
				}
			}

			Values[node.Result.Index] = new Value()
			{
				MaxValue = result ? 1u : 0u,
				MinValue = result ? 1u : 0u,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate || !hasResult,
				BitsSet = hasResult ? (result ? 1u : 0u) : 0,
				BitsClear = hasResult ? ~(result ? 1u : 0u) : 0,
				IsEvaluated = true
			};
		}

		private void MulUnsigned32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			var index = node.Result.Index;

			if (value1.AreLower32BitsKnown && value2.AreLower32BitsKnown)
			{
				Values[index] = new Value((value1.MaxValue * value2.MaxValue) & uint.MaxValue);
				return;
			}

			if (value1.AreLower32BitsKnown && (value1.MaxValue & uint.MaxValue) == 0)
			{
				Values[index] = new Value(0);
				return;
			}

			if (value2.AreLower32BitsKnown && (value2.MaxValue & uint.MaxValue) == 0)
			{
				Values[index] = new Value(0);
				return;
			}

			if (value1.AreLower32BitsKnown && (value1.MaxValue & uint.MaxValue) == 1)
			{
				Values[index] = value2;
				return;
			}

			if (value2.AreLower32BitsKnown && (value2.MaxValue & uint.MaxValue) == 1)
			{
				Values[index] = value1;
				return;
			}

			// TODO: Special power of two handling for bits, handle similar to shift left

			Values[index] = new Value()
			{
				MaxValue = (value1.MaxValue * value2.MaxValue) & uint.MaxValue,
				MinValue = (value1.MinValue * value2.MinValue) & uint.MaxValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate || IsMultiplyOverflow((uint)value1.MaxValue, (uint)value2.MaxValue),
				BitsSet = 0,
				BitsClear = Upper32BitsSet | ((value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate) ? 0 : BitTwiddling.GetClearBits(value1.MaxValue * value2.MaxValue)),
				IsEvaluated = true
			};
		}

		private void MulUnsigned64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			var index = node.Result.Index;

			if (value1.AreAll64BitsKnown && value2.AreAll64BitsKnown)
			{
				Values[index] = new Value(value1.MaxValue * value2.MaxValue);
				return;
			}

			if (value1.AreAll64BitsKnown && value1.MaxValue == 0)
			{
				Values[index] = new Value(0);
				return;
			}

			if (value2.AreAll64BitsKnown && value2.MaxValue == 0)
			{
				Values[index] = new Value(0);
				return;
			}

			if (value1.AreAll64BitsKnown && value1.MaxValue == 1)
			{
				Values[index] = value2;
				return;
			}

			if (value2.AreAll64BitsKnown && value2.MaxValue == 1)
			{
				Values[index] = value1;
				return;
			}

			// TODO: Special power of two handling for bits, handle similar to shift left
			Values[index] = new Value()
			{
				MaxValue = value1.MaxValue * value2.MaxValue,
				MinValue = value1.MinValue * value2.MinValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate || IsMultiplyOverflow(value1.MaxValue, value2.MaxValue),
				BitsSet = 0,
				BitsClear = (value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate) ? 0 : BitTwiddling.GetClearBits(value1.MaxValue * value2.MaxValue),
				IsEvaluated = true
			};
		}

		private void Add32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			var index = node.Result.Index;

			if (value1.AreLower32BitsKnown && value2.AreLower32BitsKnown)
			{
				Values[index] = new Value((value1.MaxValue + value2.MaxValue) & uint.MaxValue);
				return;
			}

			if (value1.AreLower32BitsKnown && value1.MaxValue == 0)
			{
				Values[index] = value2;
				return;
			}

			if (value2.AreLower32BitsKnown && value2.MaxValue == 0)
			{
				Values[index] = value2;
				return;
			}

			Values[index] = new Value()
			{
				MaxValue = (value1.MaxValue + value2.MaxValue) & uint.MaxValue,
				MinValue = (value1.MinValue + value2.MinValue) & uint.MaxValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate || IsAddOverflow((uint)value1.MaxValue, (uint)value2.MaxValue),
				BitsSet = 0,
				BitsClear = Upper32BitsSet | ((value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate) ? 0 : BitTwiddling.GetClearBits((value1.MaxValue + value2.MaxValue) & uint.MaxValue)),
				IsEvaluated = true
			};
		}

		private void Add64(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];
			var value2 = node.Operand2.IsConstant ? new Value(node.Operand2.ConstantUnsignedLongInteger) : Values[node.Operand2.Index];

			var index = node.Result.Index;

			if (value1.AreAll64BitsKnown && value2.AreAll64BitsKnown)
			{
				Values[index] = new Value(value1.MaxValue + value2.MaxValue);
				return;
			}

			if (value1.AreAll64BitsKnown && value1.MaxValue == 0)
			{
				Values[index] = value2;
				return;
			}

			if (value2.AreAll64BitsKnown && value2.MaxValue == 0)
			{
				Values[index] = value2;
				return;
			}

			Values[index] = new Value()
			{
				MaxValue = value1.MaxValue + value2.MaxValue,
				MinValue = value1.MinValue + value2.MinValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate || IsAddOverflow(value1.MaxValue, value2.MaxValue),
				BitsSet = 0,
				BitsClear = (value1.IsRangeValueIndeterminate || value2.IsRangeValueIndeterminate) ? 0 : BitTwiddling.GetClearBits(value1.MaxValue + value2.MaxValue),
				IsEvaluated = true
			};
		}

		private void SignExtend16x32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];

			bool knownSignedBit = ((value1.BitsKnown >> 15) & 1) == 1;

			if (!knownSignedBit)
			{
				Values[node.Result.Index] = new Value()
				{
					MaxValue = value1.MaxValue,
					MinValue = value1.MinValue,
					IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
					BitsSet = value1.BitsSet & uint.MaxValue,
					BitsClear = value1.BitsClear & uint.MaxValue,
					IsEvaluated = true
				};
				return;
			}

			bool signedA = ((value1.BitsSet >> 15) & 1) == 1;
			bool signedB = ((value1.BitsClear >> 15) & 1) != 1;
			bool signed = signedA || signedB;

			Values[node.Result.Index] = new Value()
			{
				MaxValue = value1.MaxValue,
				MinValue = value1.MinValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
				BitsSet = value1.BitsSet & uint.MaxValue | (signed ? Upper48itsSet : 0),
				BitsClear = value1.BitsClear | Upper32BitsSet | (signed ? 0 : Upper48itsSet),
				IsEvaluated = true
			};
		}

		private void SignExtend8x32(InstructionNode node)
		{
			var value1 = node.Operand1.IsConstant ? new Value(node.Operand1.ConstantUnsignedLongInteger) : Values[node.Operand1.Index];

			bool knownSignedBit = ((value1.BitsKnown >> 7) & 1) == 1;

			if (!knownSignedBit)
			{
				Values[node.Result.Index] = new Value()
				{
					MaxValue = value1.MaxValue,
					MinValue = value1.MinValue,
					IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
					BitsSet = value1.BitsSet & uint.MaxValue,
					BitsClear = value1.BitsClear & uint.MaxValue,
					IsEvaluated = true
				};
				return;
			}

			bool signedA = ((value1.BitsSet >> 7) & 1) == 1;
			bool signedB = ((value1.BitsClear >> 7) & 1) != 1;
			bool signed = signedA || signedB;

			Values[node.Result.Index] = new Value()
			{
				MaxValue = value1.MaxValue,
				MinValue = value1.MinValue,
				IsRangeValueIndeterminate = value1.IsRangeValueIndeterminate,
				BitsSet = value1.BitsSet & uint.MaxValue | (signed ? Upper56itsSet : 0),
				BitsClear = value1.BitsClear | Upper32BitsSet | (signed ? 0 : Upper56itsSet),
				IsEvaluated = true
			};
		}
	}
}