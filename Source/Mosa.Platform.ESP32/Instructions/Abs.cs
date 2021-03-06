// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ESP32.Instructions
{
	/// <summary>
	/// Abs - Absolute Value, ABS calculates the absolute value of the contents of address register at and writes it to address register ar. Arithmetic overflow is not detected.
	/// </summary>
	/// <seealso cref="Mosa.Platform.ESP32.ESP32Instruction" />
	public sealed class Abs : ESP32Instruction
	{
		public override int ID { get { return 692; } }

		internal Abs()
			: base(1, 2)
		{
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 2);

			emitter.OpcodeEncoder.AppendNibble(0b0110);
			emitter.OpcodeEncoder.AppendNibble(0b0000);
			emitter.OpcodeEncoder.AppendNibble(node.Result.Register.RegisterCode);
			emitter.OpcodeEncoder.AppendNibble(0b0001);
			emitter.OpcodeEncoder.AppendNibble(node.Operand2.Register.RegisterCode);
			emitter.OpcodeEncoder.AppendNibble(0b0000);
		}
	}
}
