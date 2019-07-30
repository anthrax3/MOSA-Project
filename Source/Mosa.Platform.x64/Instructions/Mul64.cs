// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// Mul64
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class Mul64 : X64Instruction
	{
		public override int ID { get { return 431; } }

		internal Mul64()
			: base(2, 2)
		{
		}

		public override bool IsCommutative { get { return true; } }

		public override bool IsZeroFlagUnchanged { get { return true; } }

		public override bool IsZeroFlagUndefined { get { return true; } }

		public override bool IsCarryFlagModified { get { return true; } }

		public override bool IsSignFlagUnchanged { get { return true; } }

		public override bool IsSignFlagUndefined { get { return true; } }

		public override bool IsOverflowFlagModified { get { return true; } }

		public override bool IsParityFlagUnchanged { get { return true; } }

		public override bool IsParityFlagUndefined { get { return true; } }

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 2);
			System.Diagnostics.Debug.Assert(node.OperandCount == 2);

			emitter.OpcodeEncoder.SuppressByte(0x40);
			emitter.OpcodeEncoder.AppendNibble(0b0100);
			emitter.OpcodeEncoder.AppendBit(0b1);
			emitter.OpcodeEncoder.AppendBit(0b0);
			emitter.OpcodeEncoder.AppendBit(0b0);
			emitter.OpcodeEncoder.AppendBit((node.Operand2.Register.RegisterCode >> 3) & 0x1);
			emitter.OpcodeEncoder.AppendByte(0xF7);
			emitter.OpcodeEncoder.Append2Bits(0b11);
			emitter.OpcodeEncoder.Append3Bits(0b100);
			emitter.OpcodeEncoder.Append3Bits(node.Operand2.Register.RegisterCode);
		}
	}
}
