// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// BranchLessOrEqual
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class BranchLessOrEqual : X64Instruction
	{
		public override int ID { get { return 556; } }

		internal BranchLessOrEqual()
			: base(0, 0)
		{
		}

		public override string AlternativeName { get { return "JLE"; } }

		public override FlowControl FlowControl { get { return FlowControl.ConditionalBranch; } }

		public override bool IsZeroFlagUsed { get { return true; } }

		public override bool IsSignFlagUsed { get { return true; } }

		public override bool IsOverflowFlagUsed { get { return true; } }

		public override BaseInstruction GetOpposite()
		{
			return X64.BranchGreaterThan;
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 0);
			System.Diagnostics.Debug.Assert(node.OperandCount == 0);

			emitter.OpcodeEncoder.AppendByte(0x0F);
			emitter.OpcodeEncoder.AppendByte(0x8E);
			emitter.OpcodeEncoder.EmitRelative32(node.BranchTargets[0].Label);
		}
	}
}
