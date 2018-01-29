// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	/// LoadParameterSignExtended
	/// </summary>
	/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
	public sealed class LoadParameterSignExtended : BaseIRInstruction
	{
		public LoadParameterSignExtended()
			: base(1, 1)
		{
		}

		public override bool IsMemoryRead { get { return true; } }
	}
}
