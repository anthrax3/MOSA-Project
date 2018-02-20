﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Intrinsic
{
	/// <summary>
	/// SetFS
	/// </summary>
	/// <seealso cref="Mosa.Compiler.Framework.IIntrinsicPlatformMethod" />
	internal class SetFS : IIntrinsicPlatformMethod
	{
		#region Methods

		/// <summary>
		/// Replaces the intrinsic call site
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="typeSystem">The type system.</param>
		void IIntrinsicPlatformMethod.ReplaceIntrinsicCall(Context context, MethodCompiler methodCompiler)
		{
			Operand operand1 = context.Operand1;

			Operand v1 = methodCompiler.CreateVirtualRegister(methodCompiler.TypeSystem.BuiltIn.U4);

			context.SetInstruction(X86.Mov32, v1, operand1);
			context.AppendInstruction(X86.Mov32, Operand.CreateCPURegister(methodCompiler.TypeSystem.BuiltIn.U4, SegmentRegister.FS), v1);
		}

		#endregion Methods
	}
}
