// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv6.Instructions
{
	/// <summary>
	/// Uxtb32 - Unsigned Extend Byte
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv6.ARMv6Instruction" />
	public sealed class Uxtb32 : ARMv6Instruction
	{
		public override int ID { get { return 628; } }

		internal Uxtb32()
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
