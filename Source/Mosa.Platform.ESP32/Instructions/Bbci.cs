// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ESP32.Instructions
{
	/// <summary>
	/// Bbci - Branch if Bit Clear Immediate, BBCI branches if the bit specified by the constant encoded in the bbi field of the instruction word is clear in address register as. For little-endian processors, bit 0 is the least significant bit and bit 31 is the most significant bit. For big-endian processors bit 0 is the most significant bit and bit 31 is the least significant bit. The bbi field is split, with bits 3..0 in bits 7..4 of the instruction word, and bit 4 in bit 12 of the instruction word. The target instruction address of the branch is given by the address of the BBCI instruction, plus the sign-extended 8-bit imm8 field of the instruction plus four. If the specified bit is set, execution continues with the next sequential instruction. The inverse of BBCI is BBSI.
	/// </summary>
	/// <seealso cref="Mosa.Platform.ESP32.ESP32Instruction" />
	public sealed class Bbci : ESP32Instruction
	{
		public override int ID { get { return 711; } }

		internal Bbci()
			: base(1, 3)
		{
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 3);

			emitter.OpcodeEncoder.Append8BitImmediate(node.Operand2);
			emitter.OpcodeEncoder.Append3Bits(0b011);
			emitter.OpcodeEncoder.Append2Bits((node.Result.Register.RegisterCode) & 0x11);
			emitter.OpcodeEncoder.AppendNibble(node.Operand1.Register.RegisterCode);
			emitter.OpcodeEncoder.Append3Bits((node.Result.Register.RegisterCode >> 1) & 0x111);
			emitter.OpcodeEncoder.AppendNibble(0b0111);
		}
	}
}