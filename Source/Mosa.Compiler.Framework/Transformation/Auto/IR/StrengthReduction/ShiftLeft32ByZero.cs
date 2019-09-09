// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.Auto.IR.StrengthReduction
{
	/// <summary>
	/// ShiftLeft32ByZero
	/// </summary>
	public sealed class ShiftLeft32ByZero : BaseTransformation
	{
		public ShiftLeft32ByZero() : base(IRInstruction.ShiftLeft32)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand2.IsResolvedConstant)
				return false;

			if (context.Operand2.ConstantUnsigned64 != 0)
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1;

			context.SetInstruction(IRInstruction.MoveInt32, result, t1);
		}
	}
}
