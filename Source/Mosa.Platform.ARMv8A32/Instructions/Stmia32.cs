// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv8A32.Instructions
{
	/// <summary>
	/// Stmia32 - Store Multiple Increment After
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv8A32.ARMv8A32Instruction" />
	public sealed class Stmia32 : ARMv8A32Instruction
	{
		public override int ID { get { return 690; } }

		internal Stmia32()
			: base(1, 3)
		{
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 3);

			emitter.OpcodeEncoder.Append32Bits(0x00000000);
		}
	}
}
