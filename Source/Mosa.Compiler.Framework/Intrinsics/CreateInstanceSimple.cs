﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Intrinsics
{
	/// <summary>
	/// IntrinsicMethods
	/// </summary>
	static partial class IntrinsicMethods
	{
		[IntrinsicMethod("Mosa.Runtime.Intrinsic:CreateInstanceSimple")]
		private static void CreateInstanceSimple(Context context, MethodCompiler methodCompiler)
		{
			var ctor = context.Operand1;
			var thisObject = context.Operand2;
			var result = context.Result;

			context.SetInstruction(IRInstruction.CallDynamic, null, ctor, thisObject);
			context.AppendInstruction(IRInstruction.MoveInt32, result, thisObject);
		}
	}
}
