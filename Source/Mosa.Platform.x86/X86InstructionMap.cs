﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using System.Collections.Generic;

namespace Mosa.Platform.x86
{
	/// <summary>
	/// X86 Instruction Map
	/// </summary>
	public static class X86InstructionMap
	{
		public static readonly Dictionary<string, X86Instruction> Map = new Dictionary<string, X86Instruction>() {
			{ "Adc32", X86.Adc32 },
			{ "AdcConst32", X86.AdcConst32 },
			{ "Add32", X86.Add32 },
			{ "AddConst32", X86.AddConst32 },
			{ "Addsd", X86.Addsd },
			{ "Addss", X86.Addss },
			{ "And32", X86.And32 },
			{ "AndConst32", X86.AndConst32 },
			{ "Break", X86.Break },
			{ "Btr32", X86.Btr32 },
			{ "BtrConst32", X86.BtrConst32 },
			{ "Bt32", X86.Bt32 },
			{ "BtConst32", X86.BtConst32 },
			{ "Bts32", X86.Bts32 },
			{ "BtsConst32", X86.BtsConst32 },
			{ "Call", X86.Call },
			{ "CallStatic", X86.CallStatic },
			{ "CallReg", X86.CallReg },
			{ "Cdq", X86.Cdq },
			{ "Cli", X86.Cli },
			{ "Cmp32", X86.Cmp32 },
			{ "CmpConst32", X86.CmpConst32 },
			{ "CmpXChgLoad32", X86.CmpXChgLoad32 },
			{ "Comisd", X86.Comisd },
			{ "Comiss", X86.Comiss },
			{ "CpuId", X86.CpuId },
			{ "Cvtsd2ss", X86.Cvtsd2ss },
			{ "Cvtsi2sd", X86.Cvtsi2sd },
			{ "Cvtsi2ss", X86.Cvtsi2ss },
			{ "Cvtss2sd", X86.Cvtss2sd },
			{ "Cvttsd2si", X86.Cvttsd2si },
			{ "Cvttss2si", X86.Cvttss2si },
			{ "Dec32", X86.Dec32 },
			{ "Div32", X86.Div32 },
			{ "Divsd", X86.Divsd },
			{ "Divss", X86.Divss },
			{ "JmpFar", X86.JmpFar },
			{ "Hlt", X86.Hlt },
			{ "IDiv32", X86.IDiv32 },
			{ "IMul", X86.IMul },
			{ "In8", X86.In8 },
			{ "In16", X86.In16 },
			{ "In32", X86.In32 },
			{ "InConst8", X86.InConst8 },
			{ "InConst16", X86.InConst16 },
			{ "InConst32", X86.InConst32 },
			{ "Inc32", X86.Inc32 },
			{ "Int", X86.Int },
			{ "Invlpg", X86.Invlpg },
			{ "IRetd", X86.IRetd },
			{ "Jmp", X86.Jmp },
			{ "JmpStatic", X86.JmpStatic },
			{ "JmpReg", X86.JmpReg },
			{ "Lea32", X86.Lea32 },
			{ "Leave", X86.Leave },
			{ "Lgdt", X86.Lgdt },
			{ "Lidt", X86.Lidt },
			{ "Lock", X86.Lock },
			{ "MovLoadSeg32", X86.MovLoadSeg32 },
			{ "MovStoreSeg32", X86.MovStoreSeg32 },
			{ "Mov32", X86.Mov32 },
			{ "MovConst32", X86.MovConst32 },
			{ "Movaps", X86.Movaps },
			{ "MovapsLoad", X86.MovapsLoad },
			{ "MovCRLoad", X86.MovCRLoad },
			{ "MovCRStore", X86.MovCRStore },
			{ "Movd", X86.Movd },
			{ "MovLoad8", X86.MovLoad8 },
			{ "MovLoad16", X86.MovLoad16 },
			{ "MovLoad32", X86.MovLoad32 },
			{ "Movsd", X86.Movsd },
			{ "MovsdLoad", X86.MovsdLoad },
			{ "MovsdStore", X86.MovsdStore },
			{ "Movss", X86.Movss },
			{ "MovssLoad", X86.MovssLoad },
			{ "MovssStore", X86.MovssStore },
			{ "MovStore8", X86.MovStore8 },
			{ "MovStore16", X86.MovStore16 },
			{ "MovStore32", X86.MovStore32 },
			{ "Movsx8To32", X86.Movsx8To32 },
			{ "Movsx16To32", X86.Movsx16To32 },
			{ "MovsxLoad8", X86.MovsxLoad8 },
			{ "MovsxLoad16", X86.MovsxLoad16 },
			{ "Movups", X86.Movups },
			{ "MovupsLoad", X86.MovupsLoad },
			{ "MovupsStore", X86.MovupsStore },
			{ "Movzx8To32", X86.Movzx8To32 },
			{ "Movzx16To32", X86.Movzx16To32 },
			{ "MovzxLoad8", X86.MovzxLoad8 },
			{ "MovzxLoad16", X86.MovzxLoad16 },
			{ "Mul32", X86.Mul32 },
			{ "Mulsd", X86.Mulsd },
			{ "Mulss", X86.Mulss },
			{ "Neg", X86.Neg },
			{ "Nop", X86.Nop },
			{ "Not32", X86.Not32 },
			{ "Or32", X86.Or32 },
			{ "OrConst32", X86.OrConst32 },
			{ "Out8", X86.Out8 },
			{ "Out16", X86.Out16 },
			{ "Out32", X86.Out32 },
			{ "OutConst8", X86.OutConst8 },
			{ "OutConst16", X86.OutConst16 },
			{ "OutConst32", X86.OutConst32 },
			{ "Pause", X86.Pause },
			{ "Pextrd", X86.Pextrd },
			{ "Pop32", X86.Pop32 },
			{ "Popad", X86.Popad },
			{ "Push32", X86.Push32 },
			{ "PushConst32", X86.PushConst32 },
			{ "Pushad", X86.Pushad },
			{ "PXor", X86.PXor },
			{ "Rcr32", X86.Rcr32 },
			{ "RcrConst32", X86.RcrConst32 },
			{ "RcrConstOne32", X86.RcrConstOne32 },
			{ "Rep", X86.Rep },
			{ "Ret", X86.Ret },
			{ "Roundsd", X86.Roundsd },
			{ "Roundss", X86.Roundss },
			{ "Sar32", X86.Sar32 },
			{ "SarConst32", X86.SarConst32 },
			{ "SarConstOne32", X86.SarConstOne32 },
			{ "Sbb32", X86.Sbb32 },
			{ "SbbConst32", X86.SbbConst32 },
			{ "Shl32", X86.Shl32 },
			{ "ShlConst32", X86.ShlConst32 },
			{ "ShlConstOne32", X86.ShlConstOne32 },
			{ "Shld32", X86.Shld32 },
			{ "ShldConst32", X86.ShldConst32 },
			{ "Shr32", X86.Shr32 },
			{ "ShrConst32", X86.ShrConst32 },
			{ "ShrConstOne32", X86.ShrConstOne32 },
			{ "Shrd32", X86.Shrd32 },
			{ "ShrdConst32", X86.ShrdConst32 },
			{ "Sti", X86.Sti },
			{ "Stos", X86.Stos },
			{ "Sub32", X86.Sub32 },
			{ "SubConst32", X86.SubConst32 },
			{ "Subsd", X86.Subsd },
			{ "Subss", X86.Subss },
			{ "Test32", X86.Test32 },
			{ "TestConst32", X86.TestConst32 },
			{ "Ucomisd", X86.Ucomisd },
			{ "Ucomiss", X86.Ucomiss },
			{ "XAddLoad32", X86.XAddLoad32 },
			{ "XChg32", X86.XChg32 },
			{ "XChgLoad32", X86.XChgLoad32 },
			{ "Xor32", X86.Xor32 },
			{ "XorConst32", X86.XorConst32 },
			{ "BranchOverflow", X86.BranchOverflow },
			{ "BranchNoOverflow", X86.BranchNoOverflow },
			{ "BranchCarry", X86.BranchCarry },
			{ "BranchUnsignedLessThan", X86.BranchUnsignedLessThan },
			{ "BranchUnsignedGreaterOrEqual", X86.BranchUnsignedGreaterOrEqual },
			{ "BranchNoCarry", X86.BranchNoCarry },
			{ "BranchEqual", X86.BranchEqual },
			{ "BranchZero", X86.BranchZero },
			{ "BranchNotEqual", X86.BranchNotEqual },
			{ "BranchNotZero", X86.BranchNotZero },
			{ "BranchUnsignedLessOrEqual", X86.BranchUnsignedLessOrEqual },
			{ "BranchUnsignedGreaterThan", X86.BranchUnsignedGreaterThan },
			{ "BranchSigned", X86.BranchSigned },
			{ "BranchNotSigned", X86.BranchNotSigned },
			{ "BranchParity", X86.BranchParity },
			{ "BranchNoParity", X86.BranchNoParity },
			{ "BranchLessThan", X86.BranchLessThan },
			{ "BranchGreaterOrEqual", X86.BranchGreaterOrEqual },
			{ "BranchLessOrEqual", X86.BranchLessOrEqual },
			{ "BranchGreaterThan", X86.BranchGreaterThan },
			{ "SetByteIfOverflow", X86.SetByteIfOverflow },
			{ "SetByteIfNoOverflow", X86.SetByteIfNoOverflow },
			{ "SetByteIfCarry", X86.SetByteIfCarry },
			{ "SetByteIfUnsignedLessThan", X86.SetByteIfUnsignedLessThan },
			{ "SetByteIfUnsignedGreaterOrEqual", X86.SetByteIfUnsignedGreaterOrEqual },
			{ "SetByteIfNoCarry", X86.SetByteIfNoCarry },
			{ "SetByteIfEqual", X86.SetByteIfEqual },
			{ "SetByteIfZero", X86.SetByteIfZero },
			{ "SetByteIfNotEqual", X86.SetByteIfNotEqual },
			{ "SetByteIfNotZero", X86.SetByteIfNotZero },
			{ "SetByteIfUnsignedLessOrEqual", X86.SetByteIfUnsignedLessOrEqual },
			{ "SetByteIfUnsignedGreaterThan", X86.SetByteIfUnsignedGreaterThan },
			{ "SetByteIfSigned", X86.SetByteIfSigned },
			{ "SetByteIfNotSigned", X86.SetByteIfNotSigned },
			{ "SetByteIfParity", X86.SetByteIfParity },
			{ "SetByteIfNoParity", X86.SetByteIfNoParity },
			{ "SetByteIfLessThan", X86.SetByteIfLessThan },
			{ "SetByteIfGreaterOrEqual", X86.SetByteIfGreaterOrEqual },
			{ "SetByteIfLessOrEqual", X86.SetByteIfLessOrEqual },
			{ "SetByteIfGreaterThan", X86.SetByteIfGreaterThan },
			{ "CMovOverflow32", X86.CMovOverflow32 },
			{ "CMovNoOverflow32", X86.CMovNoOverflow32 },
			{ "CMovCarry32", X86.CMovCarry32 },
			{ "CMovUnsignedLessThan32", X86.CMovUnsignedLessThan32 },
			{ "CMovUnsignedGreaterOrEqual32", X86.CMovUnsignedGreaterOrEqual32 },
			{ "CMovNoCarry32", X86.CMovNoCarry32 },
			{ "CMovEqual32", X86.CMovEqual32 },
			{ "CMovZero32", X86.CMovZero32 },
			{ "CMovNotEqual32", X86.CMovNotEqual32 },
			{ "CMovNotZero32", X86.CMovNotZero32 },
			{ "CMovUnsignedLessOrEqual32", X86.CMovUnsignedLessOrEqual32 },
			{ "CMovUnsignedGreaterThan32", X86.CMovUnsignedGreaterThan32 },
			{ "CMovSigned32", X86.CMovSigned32 },
			{ "CMovNotSigned32", X86.CMovNotSigned32 },
			{ "CMovParity32", X86.CMovParity32 },
			{ "CMovNoParity32", X86.CMovNoParity32 },
			{ "CMovLessThan32", X86.CMovLessThan32 },
			{ "CMovGreaterOrEqual32", X86.CMovGreaterOrEqual32 },
			{ "CMovLessOrEqual32", X86.CMovLessOrEqual32 },
			{ "CMovGreaterThan32", X86.CMovGreaterThan32 },
		};
	}
}
