// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transformation.Manual
{
	/// <summary>
	/// Transformations
	/// </summary>
	public static class ManualTransformation
	{
		public static readonly BaseTransformation IR_ConstantFolding_CompareInt32x32 = new IR.ConstantFolding.CompareInt32x32();
		public static readonly BaseTransformation IR_ConstantFolding_CompareInt32x64 = new IR.ConstantFolding.CompareInt32x64();
		public static readonly BaseTransformation IR_ConstantFolding_CompareInt64x32 = new IR.ConstantFolding.CompareInt64x32();
		public static readonly BaseTransformation IR_ConstantFolding_CompareInt64x64 = new IR.ConstantFolding.CompareInt64x64();

		public static readonly BaseTransformation IR_LowerTo32_Add64 = new IR.LowerTo32.Add64();
		public static readonly BaseTransformation IR_Special_CodeInDeadBlock = new Transformation.IR.Special.CodeInDeadBlock();
		public static readonly BaseTransformation IR_Special_Deadcode = new Transformation.IR.Special.Deadcode();

		public static readonly BaseTransformation IR_Simplification_Phi32 = new IR.Simplification.Phi32();
		public static readonly BaseTransformation IR_Simplification_Phi64 = new IR.Simplification.Phi64();
		public static readonly BaseTransformation IR_Simplification_PhiR4 = new IR.Simplification.PhiR4();
		public static readonly BaseTransformation IR_Simplification_PhiR8 = new IR.Simplification.PhiR8();

		public static readonly BaseTransformation IR_Simplification_AddCarryOut32CarryNotUsed = new IR.Simplification.AddCarryOut32CarryNotUsed();
		public static readonly BaseTransformation IR_Simplification_AddCarryOut64CarryNotUsed = new IR.Simplification.AddCarryOut64CarryNotUsed();
		public static readonly BaseTransformation IR_Simplification_SubCarryOut32CarryNotUsed = new IR.Simplification.SubCarryOut32CarryNotUsed();
		public static readonly BaseTransformation IR_Simplification_SubCarryOut64CarryNotUsed = new IR.Simplification.SubCarryOut64CarryNotUsed();

		public static readonly BaseTransformation IR_Simplification_CompareInt32x32Same = new IR.Simplification.CompareInt32x32Same();
		public static readonly BaseTransformation IR_Simplification_CompareInt32x64Same = new IR.Simplification.CompareInt32x64Same();
		public static readonly BaseTransformation IR_Simplification_CompareInt64x32Same = new IR.Simplification.CompareInt64x32Same();
		public static readonly BaseTransformation IR_Simplification_CompareInt64x64Same = new IR.Simplification.CompareInt64x64Same();

		public static readonly BaseTransformation IR_Simplification_CompareInt32x32NotSame = new IR.Simplification.CompareInt32x32NotSame();
		public static readonly BaseTransformation IR_Simplification_CompareInt32x64NotSame = new IR.Simplification.CompareInt32x64NotSame();
		public static readonly BaseTransformation IR_Simplification_CompareInt64x32NotSame = new IR.Simplification.CompareInt64x32NotSame();
		public static readonly BaseTransformation IR_Simplification_CompareInt64x64NotSame = new IR.Simplification.CompareInt64x64NotSame();

		public static readonly BaseTransformation IR_Special_PropagateMove32 = new Transformation.IR.Special.PropagateMove32();
		public static readonly BaseTransformation IR_Special_PropagateMove64 = new Transformation.IR.Special.PropagateMove64();
		public static readonly BaseTransformation IR_Special_PropagateMoveR4 = new Transformation.IR.Special.PropagateMoveR4();
		public static readonly BaseTransformation IR_Special_PropagateMoveR8 = new Transformation.IR.Special.PropagateMoveR8();
	}
}
