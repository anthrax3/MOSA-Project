﻿/*
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
using System.Diagnostics;

namespace Mosa.Runtime.CompilerFramework.IL
{
    public class BreakInstruction : ILInstruction
    {
        #region Construction

        public BreakInstruction(OpCode code) :
            base(code)
        {
            Debug.Assert(OpCode.Break == code, @"Wrong opcode for BreakInstruction.");
            if (OpCode.Break != code)
                throw new ArgumentException(@"Wrong opcode.", @"code");
        }

        #endregion // Construction

        #region ILInstruction Overrides

        /// <summary>
        /// Allows visitor based dispatch for this instruction object.
        /// </summary>
        /// <param name="visitor">The visitor object.</param>
        /// <param name="arg">A visitor specific context argument.</param>
        /// <typeparam name="ArgType">An additional visitor context argument.</typeparam>
        public sealed override void Visit<ArgType>(IILVisitor<ArgType> visitor, ArgType arg)
        {
            visitor.Break(this, arg);
        }

        #endregion // ILInstruction Overrides
    }
}
