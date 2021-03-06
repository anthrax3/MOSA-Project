// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;
using System.Collections.Generic;

namespace Mosa.Platform.x86
{
	/// <summary>
	/// X86 Instruction Map
	/// </summary>
	public static class X86Instructions
	{
		public static readonly List<BaseInstruction> List = new List<BaseInstruction> {
			X86.Adc32,
			X86.Add32,
			X86.Addsd,
			X86.Addss,
			X86.And32,
			X86.Break,
			X86.Btr32,
			X86.Bt32,
			X86.Bts32,
			X86.Call,
			X86.Cdq32,
			X86.Cli,
			X86.Cmp32,
			X86.CmpXChgLoad32,
			X86.Comisd,
			X86.Comiss,
			X86.CpuId,
			X86.Cvtsd2ss,
			X86.Cvtsi2sd32,
			X86.Cvtsi2ss32,
			X86.Cvtss2sd,
			X86.Cvttsd2si32,
			X86.Cvttss2si32,
			X86.Dec32,
			X86.Div32,
			X86.Divsd,
			X86.Divss,
			X86.JmpFar,
			X86.Hlt,
			X86.IDiv32,
			X86.IMul32,
			X86.In8,
			X86.In16,
			X86.In32,
			X86.Inc32,
			X86.Int,
			X86.Invlpg,
			X86.IRetd,
			X86.Jmp,
			X86.JmpExternal,
			X86.Lea32,
			X86.Leave,
			X86.Lgdt,
			X86.Lidt,
			X86.Lock,
			X86.MovLoadSeg32,
			X86.MovStoreSeg32,
			X86.Mov32,
			X86.Movaps,
			X86.MovapsLoad,
			X86.MovCRLoad32,
			X86.MovCRStore32,
			X86.Movd,
			X86.MovLoad8,
			X86.MovLoad16,
			X86.MovLoad32,
			X86.Movsd,
			X86.MovsdLoad,
			X86.MovsdStore,
			X86.Movss,
			X86.MovssLoad,
			X86.MovssStore,
			X86.MovStore8,
			X86.MovStore16,
			X86.MovStore32,
			X86.Movsx8To32,
			X86.Movsx16To32,
			X86.MovsxLoad8,
			X86.MovsxLoad16,
			X86.Movups,
			X86.MovupsLoad,
			X86.MovupsStore,
			X86.Movzx8To32,
			X86.Movzx16To32,
			X86.MovzxLoad8,
			X86.MovzxLoad16,
			X86.Mul32,
			X86.Mulsd,
			X86.Mulss,
			X86.Neg32,
			X86.Nop,
			X86.Not32,
			X86.Or32,
			X86.Out8,
			X86.Out16,
			X86.Out32,
			X86.Pause,
			X86.Pextrd32,
			X86.Pop32,
			X86.Popad,
			X86.Push32,
			X86.Pushad,
			X86.PXor,
			X86.Rcr32,
			X86.Ret,
			X86.Roundsd,
			X86.Roundss,
			X86.Sar32,
			X86.Sbb32,
			X86.Shl32,
			X86.Shld32,
			X86.Shr32,
			X86.Shrd32,
			X86.Sti,
			X86.Stos,
			X86.Sqrtss,
			X86.Sqrtsd,
			X86.Sub32,
			X86.Subsd,
			X86.Subss,
			X86.Test32,
			X86.Ucomisd,
			X86.Ucomiss,
			X86.XAddLoad32,
			X86.XChg32,
			X86.XChgLoad32,
			X86.Xor32,
			X86.BranchOverflow,
			X86.BranchNoOverflow,
			X86.BranchCarry,
			X86.BranchUnsignedLessThan,
			X86.BranchUnsignedGreaterOrEqual,
			X86.BranchNoCarry,
			X86.BranchEqual,
			X86.BranchZero,
			X86.BranchNotEqual,
			X86.BranchNotZero,
			X86.BranchUnsignedLessOrEqual,
			X86.BranchUnsignedGreaterThan,
			X86.BranchSigned,
			X86.BranchNotSigned,
			X86.BranchParity,
			X86.BranchNoParity,
			X86.BranchLessThan,
			X86.BranchGreaterOrEqual,
			X86.BranchLessOrEqual,
			X86.BranchGreaterThan,
			X86.SetByteIfOverflow,
			X86.SetByteIfNoOverflow,
			X86.SetByteIfCarry,
			X86.SetByteIfUnsignedLessThan,
			X86.SetByteIfUnsignedGreaterOrEqual,
			X86.SetByteIfNoCarry,
			X86.SetByteIfEqual,
			X86.SetByteIfZero,
			X86.SetByteIfNotEqual,
			X86.SetByteIfNotZero,
			X86.SetByteIfUnsignedLessOrEqual,
			X86.SetByteIfUnsignedGreaterThan,
			X86.SetByteIfSigned,
			X86.SetByteIfNotSigned,
			X86.SetByteIfParity,
			X86.SetByteIfNoParity,
			X86.SetByteIfLessThan,
			X86.SetByteIfGreaterOrEqual,
			X86.SetByteIfLessOrEqual,
			X86.SetByteIfGreaterThan,
			X86.CMovOverflow32,
			X86.CMovNoOverflow32,
			X86.CMovCarry32,
			X86.CMovUnsignedLessThan32,
			X86.CMovUnsignedGreaterOrEqual32,
			X86.CMovNoCarry32,
			X86.CMovEqual32,
			X86.CMovZero32,
			X86.CMovNotEqual32,
			X86.CMovNotZero32,
			X86.CMovUnsignedLessOrEqual32,
			X86.CMovUnsignedGreaterThan32,
			X86.CMovSigned32,
			X86.CMovNotSigned32,
			X86.CMovParity32,
			X86.CMovNoParity32,
			X86.CMovLessThan32,
			X86.CMovGreaterOrEqual32,
			X86.CMovLessOrEqual32,
			X86.CMovGreaterThan32,
			X86.BochsDebug,
			X86.RdMSR,
			X86.WrMSR,
		};
	}
}
