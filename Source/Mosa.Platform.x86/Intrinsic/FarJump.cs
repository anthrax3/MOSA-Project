﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;
using Mosa.Platform.Intel;

namespace Mosa.Platform.x86.Intrinsic
{
	/// <summary>
	/// IntrinsicMethods
	/// </summary>
	static partial class IntrinsicMethods
	{
		[IntrinsicMethod("Mosa.Platform.x86.Intrinsic:FarJump")]
		private static void FarJump(Context context, MethodCompiler methodCompiler)
		{
			context.SetInstruction(X86.JmpFar);
		}
	}
}
