// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ESP32.Instructions
{
	/// <summary>
	/// Any4 - Any 4 Booleans True, ANY4 sets Boolean register bt to the logical or of the four Boolean registers bs+0, bs+1, bs+2, and bs+3. bs must be a multiple of four (b0, b4, b8, or b12); otherwise the operation of this instruction is not defined. ANY4 reduces four test results such that the result is true if any of the four tests are true. When the sense of the bs Booleans is inverted (0 → true, 1 → false), use ALL4 and an inverted test of the result.
	/// </summary>
	/// <seealso cref="Mosa.Platform.ESP32.ESP32Instruction" />
	public sealed class Any4 : ESP32Instruction
	{
		public override int ID { get { return 706; } }

		internal Any4()
			: base(1, 2)
		{
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 2);

			emitter.OpcodeEncoder.AppendNibble(0b0000);
			emitter.OpcodeEncoder.AppendNibble(0b0000);
			emitter.OpcodeEncoder.AppendNibble(0b1000);
			emitter.OpcodeEncoder.AppendNibble(node.Operand1.Register.RegisterCode);
			emitter.OpcodeEncoder.AppendNibble(node.Operand2.Register.RegisterCode);
			emitter.OpcodeEncoder.AppendNibble(0b0000);
		}
	}
}
