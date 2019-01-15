// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv6.Instructions
{
	/// <summary>
	/// Stm32 - Store Multiple
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv6.ARMv6Instruction" />
	public sealed class Stm32 : ARMv6Instruction
	{
		public override int ID { get { return 665; } }

		internal Stm32()
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