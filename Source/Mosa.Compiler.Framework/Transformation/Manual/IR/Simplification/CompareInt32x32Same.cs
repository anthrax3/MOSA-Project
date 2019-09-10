﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.Manual.IR.Simplification
{
	public sealed class CompareInt32x32Same : BaseTransformation
	{
		public CompareInt32x32Same() : base(IRInstruction.CompareInt32x32)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!AreSame(context.Operand1, context.Operand2))
				return false;

			var condition = context.ConditionCode;

			return (condition == ConditionCode.Equal || condition == ConditionCode.GreaterOrEqual || condition == ConditionCode.UnsignedGreaterOrEqual || condition == ConditionCode.UnsignedLessOrEqual || condition == ConditionCode.LessOrEqual);
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var operand1 = transformContext.CreateConstant(1);
			context.SetInstruction(IRInstruction.MoveInt32, context.Result, operand1);
		}
	}
}