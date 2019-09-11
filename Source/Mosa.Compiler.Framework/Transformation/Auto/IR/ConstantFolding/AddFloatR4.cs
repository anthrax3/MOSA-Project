// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.Auto.IR.ConstantFolding
{
	/// <summary>
	/// AddFloatR4
	/// </summary>
	public sealed class AddFloatR4 : BaseTransformation
	{
		public AddFloatR4() : base(IRInstruction.AddFloatR4)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!IsResolvedConstant(context.Operand1))
				return false;

			if (!IsResolvedConstant(context.Operand2))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1;
			var t2 = context.Operand2;

			var e1 = transformContext.CreateConstant(AddR4(ToR4(t1), ToR4(t2)));

			context.SetInstruction(IRInstruction.MoveFloatR4, result, e1);
		}
	}
}
