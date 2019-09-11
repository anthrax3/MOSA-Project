﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.Manual.IR.Rewrite
{
	public sealed class CompareInt64x64GreaterThanZero : BaseTransformation
	{
		public CompareInt64x64GreaterThanZero() : base(IRInstruction.CompareInt64x64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!IsResolvedConstant(context.Operand2))
				return false;

			if (context.Operand2.ConstantUnsigned64 != 0)
				return false;

			if (context.ConditionCode != ConditionCode.UnsignedGreaterThan)
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			context.SetInstruction(IRInstruction.CompareInt64x64, ConditionCode.NotEqual, context.Result, context.Operand1, context.Operand2);
		}
	}
}
