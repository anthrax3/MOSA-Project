// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv8A32.Instructions
{
	/// <summary>
	/// AddSImm32 - Addition
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv8A32.ARMv8A32Instruction" />
	public sealed class AddSImm32 : ARMv8A32Instruction
	{
		public override int ID { get { return 581; } }

		internal AddSImm32()
			: base(1, 2)
		{
		}

		public override bool IsCommutative { get { return true; } }

		public override bool IsCarryFlagUsed { get { return true; } }

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 2);

			if (node.Operand2.IsConstant)
			{
				emitter.OpcodeEncoder.AppendNibble(GetConditionCode(node.ConditionCode));
				emitter.OpcodeEncoder.Append2Bits(0b00);
				emitter.OpcodeEncoder.AppendBit(0b1);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b1);
				emitter.OpcodeEncoder.Append4Bits(node.Operand1.Register.RegisterCode);
				emitter.OpcodeEncoder.Append4Bits(node.Result.Register.RegisterCode);
				emitter.OpcodeEncoder.Append12BitImmediate(node.Operand2);
				return;
			}

			throw new Compiler.Common.Exceptions.CompilerException("Invalid Opcode");
		}
	}
}
