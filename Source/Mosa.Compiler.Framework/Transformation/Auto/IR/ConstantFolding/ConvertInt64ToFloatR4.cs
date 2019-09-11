// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.Auto.IR.ConstantFolding
{
	/// <summary>
	/// ConvertInt64ToFloatR4
	/// </summary>
	public sealed class ConvertInt64ToFloatR4 : BaseTransformation
	{
		public ConvertInt64ToFloatR4() : base(IRInstruction.ConvertInt64ToFloatR4)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!IsResolvedConstant(context.Operand1))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1;

			var e1 = transformContext.CreateConstant(ToR4(ToSignedInt64(t1)));

			context.SetInstruction(IRInstruction.MoveFloatR4, result, e1);
		}
	}
}
