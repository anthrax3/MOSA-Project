// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.Auto.IR.StrengthReduction
{
	/// <summary>
	/// MulUnsigned32ByPowerOfTwo
	/// </summary>
	public sealed class MulUnsigned32ByPowerOfTwo : BaseTransformation
	{
		public MulUnsigned32ByPowerOfTwo() : base(IRInstruction.MulUnsigned32)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!IsPowerOfTwo32(context.Operand2))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1;
			var t2 = context.Operand2;

			var e1 = transformContext.CreateConstant(GetPowerOfTwo(t2));

			context.SetInstruction(IRInstruction.ShiftLeft32, result, t1, e1);
		}
	}
}
