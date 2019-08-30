﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.IR.ConstantFolding
{
	public sealed class ConvertInt64ToFloatR8 : BaseTransformation
	{
		public ConvertInt64ToFloatR8() : base(IRInstruction.ConvertInt64ToFloatR8, OperandFilter.ResolvedConstant)
		{
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			SetConstantResult(context, (double)context.Operand1.ConstantUnsignedLongInteger);
		}
	}
}
