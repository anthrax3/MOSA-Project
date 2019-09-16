// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using System.Collections.Generic;

namespace Mosa.Compiler.Framework.Transform.Manual
{
	/// <summary>
	/// Transformations
	/// </summary>
	public static class ManualTransforms
	{
		public static readonly List<BaseTransformation> List = new List<BaseTransformation>
		{
			ManualInstance.IR_ConstantMove_Compare32x32,
			ManualInstance.IR_ConstantMove_Compare32x64,
			ManualInstance.IR_ConstantMove_Compare64x32,
			ManualInstance.IR_ConstantMove_Compare64x64,

			ManualInstance.IR_ConstantMove_CompareBranch32,
			ManualInstance.IR_ConstantMove_CompareBranch64,

			ManualInstance.IR_Rewrite_Compare32x32,
			ManualInstance.IR_Rewrite_Compare32x64,
			ManualInstance.IR_Rewrite_Compare64x32,
			ManualInstance.IR_Rewrite_Compare64x64,

			ManualInstance.IR_ConstantFolding_Compare32x32,
			ManualInstance.IR_ConstantFolding_Compare32x64,
			ManualInstance.IR_ConstantFolding_Compare64x32,
			ManualInstance.IR_ConstantFolding_Compare64x64,

			ManualInstance.IR_ConstantFolding_CompareBranch32,
			ManualInstance.IR_ConstantFolding_CompareBranch64,

			//ManualTransformation.IR_LowerTo32_Add64,
			ManualInstance.IR_Special_CodeInDeadBlock,
			ManualInstance.IR_Special_Deadcode,

			ManualInstance.IR_Simplification_AddCarryOut32CarryNotUsed,
			ManualInstance.IR_Simplification_AddCarryOut64CarryNotUsed,
			ManualInstance.IR_Simplification_SubCarryOut32CarryNotUsed,
			ManualInstance.IR_Simplification_SubCarryOut64CarryNotUsed,

			ManualInstance.IR_Simplification_Compare32x32Same,
			ManualInstance.IR_Simplification_Compare32x64Same,
			ManualInstance.IR_Simplification_Compare64x32Same,
			ManualInstance.IR_Simplification_Compare64x64Same,

			ManualInstance.IR_Simplification_Compare32x32NotSame,
			ManualInstance.IR_Simplification_Compare32x64NotSame,
			ManualInstance.IR_Simplification_Compare64x32NotSame,
			ManualInstance.IR_Simplification_Compare64x64NotSame,

			ManualInstance.IR_Special_Move32Propagate,
			ManualInstance.IR_Special_Move64Propagate,
			ManualInstance.IR_Special_MoveR4Propagate,
			ManualInstance.IR_Special_MoveR8Propagate,

			ManualInstance.IR_Special_Phi32Propagate,
			ManualInstance.IR_Special_Phi64Propagate,
			ManualInstance.IR_Special_PhiR4Propagate,
			ManualInstance.IR_Special_PhiR8Propagate,

			ManualInstance.IR_Special_Phi32Dead,
			ManualInstance.IR_Special_Phi64Dead,
			ManualInstance.IR_Special_PhiR4Dead,
			ManualInstance.IR_Special_PhiR8Dead,

			ManualInstance.IR_Simplification_CompareBranch32OnlyOneExit,
			ManualInstance.IR_Simplification_CompareBranch64OnlyOneExit,

			ManualInstance.IR_Rewrite_CompareBranch32,
			ManualInstance.IR_Rewrite_CompareBranch64,

			ManualInstance.IR_Special_MoveCompoundPropagate,

			//ManualInstance.IR_Rewrite_CompareBranch32From64,
			//ManualInstance.IR_Rewrite_CompareBranch64From32,

			ManualInstance.IR_Special_Move32PropagateConstant,
			ManualInstance.IR_Special_Move64PropagateConstant,

			//ManualInstance..IR_Simplification_Phi32,
			//ManualInstance..IR_Simplification_Phi64,
			//ManualInstance..IR_Simplification_PhiR4,
			//ManualInstance..IR_Simplification_PhiR8,

			//ManualInstance.IR_Special_Phi32Invalid,
			//ManualInstance.IR_Special_Phi64Invalid,
			//ManualInstance.IR_Special_PhiR4Invalid,
			//ManualInstance.IR_Special_PhiR8Invalid,

			ManualInstance.IR_Rewrite_Compare32x32Combine32x32,
			ManualInstance.IR_Rewrite_Compare32x32Combine64x64,
			ManualInstance.IR_Rewrite_Compare32x32Combine64x32,
			ManualInstance.IR_Rewrite_Compare64x64Combine64x64,
			ManualInstance.IR_Rewrite_Compare64x64Combine32x32,

			ManualInstance.IR_Rewrite_CompareBranch32Combine32x32,
			ManualInstance.IR_Rewrite_CompareBranch32Combine32x64,
			ManualInstance.IR_Rewrite_CompareBranch32Combine64x32,
			ManualInstance.IR_Rewrite_CompareBranch32Combine64x64,
			ManualInstance.IR_Rewrite_CompareBranch64Combine32x32,
			ManualInstance.IR_Rewrite_CompareBranch64Combine32x64,
			ManualInstance.IR_Rewrite_CompareBranch64Combine64x32,
			ManualInstance.IR_Rewrite_CompareBranch64Combine64x64,
		};
	}
}
