// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using System.Collections.Generic;

namespace Mosa.Compiler.Framework.Transform.Auto
{
	/// <summary>
	/// Transformations
	/// </summary>
	public static class AutoTransforms
	{
		public static readonly List<BaseTransformation> List = new List<BaseTransformation> {
			AutoInstance.IR_ConstantFolding_Add32,
			AutoInstance.IR_ConstantFolding_Add64,
			AutoInstance.IR_ConstantFolding_AddR4,
			AutoInstance.IR_ConstantFolding_AddR8,
			AutoInstance.IR_ConstantFolding_AddCarryIn32,
			AutoInstance.IR_ConstantFolding_AddCarryIn64,
			AutoInstance.IR_ConstantFolding_ShiftRight32,
			AutoInstance.IR_ConstantFolding_ShiftRight64,
			AutoInstance.IR_ConstantFolding_ShiftLeft32,
			AutoInstance.IR_ConstantFolding_ShiftLeft64,
			AutoInstance.IR_ConstantFolding_DivUnsigned32,
			AutoInstance.IR_ConstantFolding_DivUnsigned64,
			AutoInstance.IR_ConstantFolding_DivSigned32,
			AutoInstance.IR_ConstantFolding_DivSigned64,
			AutoInstance.IR_ConstantFolding_DivR8,
			AutoInstance.IR_ConstantFolding_DivR4,
			AutoInstance.IR_ConstantFolding_GetHigh64,
			AutoInstance.IR_ConstantFolding_GetLow64,
			AutoInstance.IR_ConstantFolding_To64,
			AutoInstance.IR_ConstantFolding_And32,
			AutoInstance.IR_ConstantFolding_And64,
			AutoInstance.IR_ConstantFolding_Or32,
			AutoInstance.IR_ConstantFolding_Or64,
			AutoInstance.IR_ConstantFolding_Xor32,
			AutoInstance.IR_ConstantFolding_Xor64,
			AutoInstance.IR_ConstantFolding_Not32,
			AutoInstance.IR_ConstantFolding_Not64,
			AutoInstance.IR_ConstantFolding_MulUnsigned32,
			AutoInstance.IR_ConstantFolding_MulUnsigned64,
			AutoInstance.IR_ConstantFolding_MulSigned32,
			AutoInstance.IR_ConstantFolding_MulSigned64,
			AutoInstance.IR_ConstantFolding_MulR4,
			AutoInstance.IR_ConstantFolding_MulR8,
			AutoInstance.IR_ConstantFolding_RemUnsigned32,
			AutoInstance.IR_ConstantFolding_RemUnsigned64,
			AutoInstance.IR_ConstantFolding_RemSigned32,
			AutoInstance.IR_ConstantFolding_RemSigned64,
			AutoInstance.IR_ConstantFolding_RemR4,
			AutoInstance.IR_ConstantFolding_RemR8,
			AutoInstance.IR_ConstantFolding_Sub32,
			AutoInstance.IR_ConstantFolding_Sub64,
			AutoInstance.IR_ConstantFolding_SubR4,
			AutoInstance.IR_ConstantFolding_SubR8,
			AutoInstance.IR_ConstantFolding_SubCarryIn32,
			AutoInstance.IR_ConstantFolding_SubCarryIn64,
			AutoInstance.IR_ConstantFolding_SignExtend16x32,
			AutoInstance.IR_ConstantFolding_SignExtend16x64,
			AutoInstance.IR_ConstantFolding_SignExtend32x64,
			AutoInstance.IR_ConstantFolding_SignExtend8x32,
			AutoInstance.IR_ConstantFolding_SignExtend8x64,
			AutoInstance.IR_ConstantFolding_ZeroExtend16x32,
			AutoInstance.IR_ConstantFolding_ZeroExtend16x64,
			AutoInstance.IR_ConstantFolding_ZeroExtend32x64,
			AutoInstance.IR_ConstantFolding_ZeroExtend8x32,
			AutoInstance.IR_ConstantFolding_ZeroExtend8x64,
			AutoInstance.IR_ConstantFolding_Convert32ToR4,
			AutoInstance.IR_ConstantFolding_Convert32ToR8,
			AutoInstance.IR_ConstantFolding_Convert64ToR4,
			AutoInstance.IR_ConstantFolding_Convert64ToR8,
			AutoInstance.IR_ConstantFolding_IfThenElse32AlwaysTrue,
			AutoInstance.IR_ConstantFolding_IfThenElse64AlwaysTrue,
			AutoInstance.IR_ConstantFolding_IfThenElse32AlwaysFalse,
			AutoInstance.IR_ConstantFolding_IfThenElse64AlwaysFalse,
			AutoInstance.IR_Simplification_Move32Propogation,
			AutoInstance.IR_Simplification_Move64Propogation,
			AutoInstance.IR_Simplification_Not32Twice,
			AutoInstance.IR_Simplification_Not64Twice,
			AutoInstance.IR_Simplification_Add32Combine,
			AutoInstance.IR_Simplification_Add64Combine,
			AutoInstance.IR_Simplification_AddR4Combine,
			AutoInstance.IR_Simplification_AddR8Combine,
			AutoInstance.IR_Simplification_Sub32Combine,
			AutoInstance.IR_Simplification_Sub64Combine,
			AutoInstance.IR_Simplification_SubR4Combine,
			AutoInstance.IR_Simplification_SubR8Combine,
			AutoInstance.IR_Simplification_MulSigned32,
			AutoInstance.IR_Simplification_MulSigned64,
			AutoInstance.IR_Simplification_MulR4,
			AutoInstance.IR_Simplification_MulR8,
			AutoInstance.IR_Simplification_MulUnsigned32,
			AutoInstance.IR_Simplification_MulUnsigned64,
			AutoInstance.IR_Simplification_Or32Combine,
			AutoInstance.IR_Simplification_Or64Combine,
			AutoInstance.IR_Simplification_And32Combine,
			AutoInstance.IR_Simplification_And64Combine,
			AutoInstance.IR_Simplification_Xor32Combine,
			AutoInstance.IR_Simplification_Xor64Combine,
			AutoInstance.IR_Simplification_AddSub32Combine,
			AutoInstance.IR_Simplification_AddSub64Combine,
			AutoInstance.IR_Simplification_AddSubR4Combine,
			AutoInstance.IR_Simplification_AddSubR8Combine,
			AutoInstance.IR_Simplification_SubAdd32Combine,
			AutoInstance.IR_Simplification_SubAdd64Combine,
			AutoInstance.IR_Simplification_SubAddR4Combine,
			AutoInstance.IR_Simplification_SubAddR8Combine,
			AutoInstance.IR_Simplification_GetLow64FromTo64,
			AutoInstance.IR_Simplification_GetHigh64FromTo64,
			AutoInstance.IR_Simplification_GetHigh64To64,
			AutoInstance.IR_Simplification_GetLow64To64,
			AutoInstance.IR_Simplification_To64FromLowHigh,
			AutoInstance.IR_Simplification_GetLow64FromShiftedRight32,
			AutoInstance.IR_Simplification_GetLow64FromRightShiftAndTo64,
			AutoInstance.IR_Simplification_GetHigh64FromRightLeftAndTo64,
			AutoInstance.IR_Simplification_GetHigh64FromShiftedMore32,
			AutoInstance.IR_Simplification_GetLow64FromShiftedMore32,
			AutoInstance.IR_StrengthReduction_And32Zero,
			AutoInstance.IR_StrengthReduction_And64Zero,
			AutoInstance.IR_StrengthReduction_And32Max,
			AutoInstance.IR_StrengthReduction_And64Max,
			AutoInstance.IR_StrengthReduction_Or32Max,
			AutoInstance.IR_StrengthReduction_Or64Max,
			AutoInstance.IR_StrengthReduction_Or32Zero,
			AutoInstance.IR_StrengthReduction_Or64Zero,
			AutoInstance.IR_StrengthReduction_Xor32Zero,
			AutoInstance.IR_StrengthReduction_Xor64Zero,
			AutoInstance.IR_StrengthReduction_Xor32Max,
			AutoInstance.IR_StrengthReduction_Xor64Max,
			AutoInstance.IR_StrengthReduction_Add32Zero,
			AutoInstance.IR_StrengthReduction_Add64Zero,
			AutoInstance.IR_StrengthReduction_ShiftRight32ZeroValue,
			AutoInstance.IR_StrengthReduction_ShiftRight32ByZero,
			AutoInstance.IR_StrengthReduction_ShiftRight64ZeroValue,
			AutoInstance.IR_StrengthReduction_ShiftRight64ByZero,
			AutoInstance.IR_StrengthReduction_ShiftLeft32ByZero,
			AutoInstance.IR_StrengthReduction_ShiftLeft64ByZero,
			AutoInstance.IR_StrengthReduction_Sub32ByZero,
			AutoInstance.IR_StrengthReduction_Sub64ByZero,
			AutoInstance.IR_StrengthReduction_Sub32Same,
			AutoInstance.IR_StrengthReduction_Sub64Same,
			AutoInstance.IR_StrengthReduction_Xor32Same,
			AutoInstance.IR_StrengthReduction_Xor64Same,
			AutoInstance.IR_StrengthReduction_MulUnsigned32ByPowerOfTwo,
			AutoInstance.IR_StrengthReduction_MulUnsigned64ByPowerOfTwo,
			AutoInstance.IR_StrengthReduction_MulSigned32ByPowerOfTwo,
			AutoInstance.IR_StrengthReduction_MulSigned64ByPowerOfTwo,
			AutoInstance.IR_StrengthReduction_DivUnsigned32ByPowerOfTwo,
			AutoInstance.IR_StrengthReduction_DivUnsigned64ByPowerOfTwo,
			AutoInstance.IR_StrengthReduction_DivSigned32ByPowerOfTwo,
			AutoInstance.IR_StrengthReduction_DivSigned64ByPowerOfTwo,
			AutoInstance.IR_StrengthReduction_RemUnsigned32ByPowerOfTwo,
			AutoInstance.IR_StrengthReduction_RemUnsigned64ByPowerOfTwo,
			AutoInstance.IR_Rewrite_Add32MultipleWithCommon,
			AutoInstance.IR_Rewrite_Add64MultipleWithCommon,
			AutoInstance.IR_Rewrite_Sub32MultipleWithCommon,
			AutoInstance.IR_Rewrite_Sub64MultipleWithCommon,
			AutoInstance.IR_Rewrite_Load32FoldAdd32,
			AutoInstance.IR_Rewrite_Load64FoldAdd32,
			AutoInstance.IR_Rewrite_LoadR4FoldAdd32,
			AutoInstance.IR_Rewrite_LoadR8FoldAdd32,
			AutoInstance.IR_Rewrite_LoadSignExtend8x32FoldAdd32,
			AutoInstance.IR_Rewrite_LoadSignExtend16x32FoldAdd32,
			AutoInstance.IR_Rewrite_LoadSignExtend8x64FoldAdd32,
			AutoInstance.IR_Rewrite_LoadSignExtend16x64FoldAdd32,
			AutoInstance.IR_Rewrite_LoadSignExtend32x64FoldAdd32,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x32FoldAdd32,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x32FoldAdd32,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x64FoldAdd32,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x64FoldAdd32,
			AutoInstance.IR_Rewrite_LoadZeroExtend32x64FoldAdd32,
			AutoInstance.IR_Rewrite_Load32FoldAdd64,
			AutoInstance.IR_Rewrite_Load64FoldAdd64,
			AutoInstance.IR_Rewrite_LoadR4FoldAdd64,
			AutoInstance.IR_Rewrite_LoadR8FoldAdd64,
			AutoInstance.IR_Rewrite_LoadSignExtend8x32FoldAdd64,
			AutoInstance.IR_Rewrite_LoadSignExtend16x32FoldAdd64,
			AutoInstance.IR_Rewrite_LoadSignExtend8x64FoldAdd64,
			AutoInstance.IR_Rewrite_LoadSignExtend16x64FoldAdd64,
			AutoInstance.IR_Rewrite_LoadSignExtend32x64FoldAdd64,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x32FoldAdd64,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x32FoldAdd64,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x64FoldAdd64,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x64FoldAdd64,
			AutoInstance.IR_Rewrite_LoadZeroExtend32x64FoldAdd64,
			AutoInstance.IR_Rewrite_Load32FoldSub32,
			AutoInstance.IR_Rewrite_Load64FoldSub32,
			AutoInstance.IR_Rewrite_LoadR4FoldSub32,
			AutoInstance.IR_Rewrite_LoadR8FoldSub32,
			AutoInstance.IR_Rewrite_LoadSignExtend8x32FoldSub32,
			AutoInstance.IR_Rewrite_LoadSignExtend16x32FoldSub32,
			AutoInstance.IR_Rewrite_LoadSignExtend8x64FoldSub32,
			AutoInstance.IR_Rewrite_LoadSignExtend16x64FoldSub32,
			AutoInstance.IR_Rewrite_LoadSignExtend32x64FoldSub32,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x32FoldSub32,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x32FoldSub32,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x64FoldSub32,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x64FoldSub32,
			AutoInstance.IR_Rewrite_LoadZeroExtend32x64FoldSub32,
			AutoInstance.IR_Rewrite_Load32FoldSub64,
			AutoInstance.IR_Rewrite_Load64FoldSub64,
			AutoInstance.IR_Rewrite_LoadR4FoldSub64,
			AutoInstance.IR_Rewrite_LoadR8FoldSub64,
			AutoInstance.IR_Rewrite_LoadSignExtend8x32FoldSub64,
			AutoInstance.IR_Rewrite_LoadSignExtend16x32FoldSub64,
			AutoInstance.IR_Rewrite_LoadSignExtend8x64FoldSub64,
			AutoInstance.IR_Rewrite_LoadSignExtend16x64FoldSub64,
			AutoInstance.IR_Rewrite_LoadSignExtend32x64FoldSub64,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x32FoldSub64,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x32FoldSub64,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x64FoldSub64,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x64FoldSub64,
			AutoInstance.IR_Rewrite_LoadZeroExtend32x64FoldSub64,
			AutoInstance.IR_Rewrite_Store8FoldAdd32,
			AutoInstance.IR_Rewrite_Store8FoldAdd64,
			AutoInstance.IR_Rewrite_Store8FoldSub32,
			AutoInstance.IR_Rewrite_Store8FoldSub64,
			AutoInstance.IR_Rewrite_Store16FoldAdd32,
			AutoInstance.IR_Rewrite_Store16FoldAdd64,
			AutoInstance.IR_Rewrite_Store16FoldSub32,
			AutoInstance.IR_Rewrite_Store16FoldSub64,
			AutoInstance.IR_Rewrite_Store32FoldAdd32,
			AutoInstance.IR_Rewrite_Store32FoldAdd64,
			AutoInstance.IR_Rewrite_Store32FoldSub32,
			AutoInstance.IR_Rewrite_Store32FoldSub64,
			AutoInstance.IR_Rewrite_Store64FoldAdd32,
			AutoInstance.IR_Rewrite_Store64FoldAdd64,
			AutoInstance.IR_Rewrite_Store64FoldSub32,
			AutoInstance.IR_Rewrite_Store64FoldSub64,
			AutoInstance.IR_Rewrite_StoreR4FoldAdd32,
			AutoInstance.IR_Rewrite_StoreR4FoldAdd64,
			AutoInstance.IR_Rewrite_StoreR4FoldSub32,
			AutoInstance.IR_Rewrite_StoreR4FoldSub64,
			AutoInstance.IR_Rewrite_StoreR8FoldAdd32,
			AutoInstance.IR_Rewrite_StoreR8FoldAdd64,
			AutoInstance.IR_Rewrite_StoreR8FoldSub32,
			AutoInstance.IR_Rewrite_StoreR8FoldSub64,
			AutoInstance.IR_Rewrite_Load32AddressFold,
			AutoInstance.IR_Rewrite_Load64AddressFold,
			AutoInstance.IR_Rewrite_LoadR4AddressFold,
			AutoInstance.IR_Rewrite_LoadR8AddressFold,
			AutoInstance.IR_Rewrite_LoadSignExtend8x32AddressFold,
			AutoInstance.IR_Rewrite_LoadSignExtend16x32AddressFold,
			AutoInstance.IR_Rewrite_LoadSignExtend8x64AddressFold,
			AutoInstance.IR_Rewrite_LoadSignExtend16x64AddressFold,
			AutoInstance.IR_Rewrite_LoadSignExtend32x64AddressFold,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x32AddressFold,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x32AddressFold,
			AutoInstance.IR_Rewrite_LoadZeroExtend8x64AddressFold,
			AutoInstance.IR_Rewrite_LoadZeroExtend16x64AddressFold,
			AutoInstance.IR_Rewrite_LoadZeroExtend32x64AddressFold,
			AutoInstance.IR_Rewrite_Truncate64x32Add64FromZeroExtended32x64,
			AutoInstance.IR_Rewrite_Truncate64x32Sub64FromZeroExtended32x64,
			AutoInstance.IR_Rewrite_Truncate64x32MulUnsigned64FromZeroExtended32x64,
			AutoInstance.IR_ConstantMove_Add32,
			AutoInstance.IR_ConstantMove_Add64,
			AutoInstance.IR_ConstantMove_AddR4,
			AutoInstance.IR_ConstantMove_AddR8,
			AutoInstance.IR_ConstantMove_MulSigned32,
			AutoInstance.IR_ConstantMove_MulSigned64,
			AutoInstance.IR_ConstantMove_MulUnsigned32,
			AutoInstance.IR_ConstantMove_MulUnsigned64,
			AutoInstance.IR_ConstantMove_MulR4,
			AutoInstance.IR_ConstantMove_MulR8,
			AutoInstance.IR_ConstantMove_And32,
			AutoInstance.IR_ConstantMove_And64,
			AutoInstance.IR_ConstantMove_Or32,
			AutoInstance.IR_ConstantMove_Or64,
			AutoInstance.IR_ConstantMove_Xor32,
			AutoInstance.IR_ConstantMove_Xor64,
		};
	}
}
