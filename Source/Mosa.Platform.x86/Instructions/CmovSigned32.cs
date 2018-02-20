// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	/// CmovSigned32
	/// </summary>
	/// <seealso cref="Mosa.Platform.x86.X86Instruction" />
	public sealed class CmovSigned32 : X86Instruction
	{
		public override string AlternativeName { get { return "CmovS32"; } }

		public static readonly LegacyOpCode LegacyOpcode = new LegacyOpCode(new byte[] { 0x0F, 0x48 } );

		internal CmovSigned32()
			: base(1, 1)
		{
		}

		public override BaseInstruction GetOpposite()
		{
			return X86.CmovNotSigned32;
		}

		internal override void EmitLegacy(InstructionNode node, X86CodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 1);

			emitter.Emit(LegacyOpcode, node.Result, node.Operand1);
		}
	}
}

