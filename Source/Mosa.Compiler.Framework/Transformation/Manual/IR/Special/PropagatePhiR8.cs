﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.Manual.IR.Special
{
	public sealed class PropagatePhiR8 : BaseTransformation
	{
		public PropagatePhiR8() : base(IRInstruction.PhiR8)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			return context.OperandCount == 1;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;
			var operand1 = context.Operand1;

			foreach (var use in result.Uses.ToArray())
			{
				for (int i = 0; i < use.OperandCount; i++)
				{
					var operand = use.GetOperand(i);

					if (operand == result)
					{
						use.SetOperand(i, operand1);
					}
				}
			}

			context.SetInstruction(IRInstruction.Nop);
		}
	}
}
