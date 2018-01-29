// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	/// MemoryCopy
	/// </summary>
	/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
	public sealed class MemoryCopy : BaseIRInstruction
	{
		public MemoryCopy()
			: base(3, 1)
		{
		}

		public override bool IsMemoryWrite { get { return true; } }
	}
}
