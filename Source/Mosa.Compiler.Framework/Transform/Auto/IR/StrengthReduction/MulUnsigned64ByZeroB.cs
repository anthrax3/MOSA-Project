// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transform.Auto.IR.StrengthReduction
{
	/// <summary>
	/// MulUnsigned64ByZeroB
	/// </summary>
	public sealed class MulUnsigned64ByZeroB : BaseTransformation
	{
		public MulUnsigned64ByZeroB() : base(IRInstruction.MulUnsigned64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsResolvedConstant)
				return false;

			if (context.Operand1.ConstantUnsigned64 != 0L)
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var c1 = transformContext.CreateConstant(0L);

			context.SetInstruction(IRInstruction.Move64, result, c1);
		}
	}
}