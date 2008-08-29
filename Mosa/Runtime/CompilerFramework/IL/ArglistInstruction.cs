/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Ruck (<mailto:sharpos@michaelruck.de>)
 */

using System;
using System.Collections.Generic;
using System.Text;
using Mosa.Runtime.Metadata;
using Mosa.Runtime.Metadata.Signatures;

namespace Mosa.Runtime.CompilerFramework.IL
{
    public class ArglistInstruction : ILInstruction
    {
        #region Construction

        public ArglistInstruction(OpCode code)
            : base(code, 0, 1)
        {
            if (OpCode.Arglist != code)
                throw new ArgumentException(@"code");
        }

        #endregion // Construction

        #region Methods

        public sealed override void Decode(IInstructionDecoder decoder)
        {
            // Decode the base class first
            base.Decode(decoder);

            // Setup the result operand
            throw new NotImplementedException();
            SetResult(0, null);
                //CreateResultOperand(MetadataTypeReference.FromName(decoder.Metadata, @"System", @"RuntimeArgumentHandle")) 
        }

        /// <summary>
        /// Allows visitor based dispatch for this instruction object.
        /// </summary>
        /// <param name="visitor">The visitor object.</param>
        /// <param name="arg">A visitor specific context argument.</param>
        /// <typeparam name="ArgType">An additional visitor context argument.</typeparam>
        public sealed override void Visit<ArgType>(IILVisitor<ArgType> visitor, ArgType arg)
        {
            visitor.Arglist(this, arg);
        }

        #endregion // Methods
    }
}
