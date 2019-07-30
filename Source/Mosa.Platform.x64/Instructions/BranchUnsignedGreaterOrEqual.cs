// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// BranchUnsignedGreaterOrEqual
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class BranchUnsignedGreaterOrEqual : X64Instruction
	{
		public override int ID { get { return 492; } }

		internal BranchUnsignedGreaterOrEqual()
			: base(0, 0)
		{
		}

		public override string AlternativeName { get { return "JAE"; } }

		public override FlowControl FlowControl { get { return FlowControl.ConditionalBranch; } }

		public override bool IsCarryFlagUsed { get { return true; } }

		public override BaseInstruction GetOpposite()
		{
			return X64.BranchUnsignedLessThan;
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 0);
			System.Diagnostics.Debug.Assert(node.OperandCount == 0);

			emitter.OpcodeEncoder.AppendByte(0x0F);
			emitter.OpcodeEncoder.AppendByte(0x83);
			emitter.OpcodeEncoder.EmitRelative32(node.BranchTargets[0].Label);
		}
	}
}
