// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// SetByteIfCarry
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class SetByteIfCarry : X64Instruction
	{
		public override int ID { get { return 510; } }

		internal SetByteIfCarry()
			: base(1, 0)
		{
		}

		public override string AlternativeName { get { return "SetC"; } }

		public override bool IsCarryFlagUsed { get { return true; } }

		public override BaseInstruction GetOpposite()
		{
			return X64.SetByteIfNoCarry;
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 0);

			emitter.OpcodeEncoder.AppendByte(0x0F);
			emitter.OpcodeEncoder.SuppressByte(0x40);
			emitter.OpcodeEncoder.AppendNibble(0b0100);
			emitter.OpcodeEncoder.AppendBit(0b1);
			emitter.OpcodeEncoder.AppendBit(0b0);
			emitter.OpcodeEncoder.AppendBit(0b0);
			emitter.OpcodeEncoder.AppendBit((node.Result.Register.RegisterCode >> 3) & 0x1);
			emitter.OpcodeEncoder.AppendByte(0x92);
			emitter.OpcodeEncoder.Append2Bits(0b11);
			emitter.OpcodeEncoder.Append3Bits(0b000);
			emitter.OpcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
		}
	}
}
