/*
 * (c) 2012 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

using Mosa.Compiler.Framework;

namespace Mosa.Platform.AVR32.Instructions
{
	/// <summary>
	/// 
	/// </summary>
	public class RetInstruction : BaseInstruction
	{

        #region Properties

        /// <summary>
        /// Gets the instruction latency.
        /// </summary>
        /// <value>The latency.</value>
        public override int Latency { get { return 1; } }

        #endregion // Properties

		#region Methods

		/// <summary>
		/// Emits the specified platform instruction.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="emitter">The emitter.</param>
		protected override void Emit(Context context, MachineCodeEmitter emitter)
		{
            emitter.EmitReturnAndTest(0x00);
		}

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor object.</param>
		/// <param name="context">The context.</param>
		public override void Visit(IAVR32Visitor visitor, Context context)
		{
			visitor.Ret(context);
		}

		#endregion // Methods

	}
}