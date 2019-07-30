// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// XChg32
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class XChg32 : X64Instruction
	{
		public override int ID { get { return 502; } }

		internal XChg32()
			: base(2, 2)
		{
		}

		public override bool IsCommutative { get { return true; } }

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 2);
			System.Diagnostics.Debug.Assert(node.OperandCount == 2);

			emitter.OpcodeEncoder.SuppressByte(0x40);
			emitter.OpcodeEncoder.AppendNibble(0b0100);
			emitter.OpcodeEncoder.AppendBit(0b0);
			emitter.OpcodeEncoder.AppendBit((node.Operand2.Register.RegisterCode >> 3) & 0x1);
			emitter.OpcodeEncoder.AppendBit(0b0);
			emitter.OpcodeEncoder.AppendBit((node.Operand1.Register.RegisterCode >> 3) & 0x1);
			emitter.OpcodeEncoder.AppendByte(0x87);
			emitter.OpcodeEncoder.Append2Bits(0b11);
			emitter.OpcodeEncoder.Append3Bits(node.Operand2.Register.RegisterCode);
			emitter.OpcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
		}
	}
}
