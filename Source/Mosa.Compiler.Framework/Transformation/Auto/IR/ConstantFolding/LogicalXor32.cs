// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.Auto.IR.ConstantFolding
{
	/// <summary>
	/// LogicalXor32
	/// </summary>
	public sealed class LogicalXor32 : BaseTransformation
	{
		public LogicalXor32() : base(IRInstruction.LogicalXor32)
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

			var e1 = transformContext.CreateConstant(Xor32(ToInt32(t1), ToInt32(t2)));

			context.SetInstruction(IRInstruction.MoveInt32, result, e1);
		}
	}
}
