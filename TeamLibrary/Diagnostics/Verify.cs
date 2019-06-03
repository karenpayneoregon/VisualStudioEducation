﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.Diagnostics
{
    /*
     * https://github.com/CoolDadTx/kraken
     */
    [DebuggerStepThrough]
    public static class Verify
    {
        /// <summary>Creates an argument that can be verified.</summary>
        /// <param name="name">The argument name.</param>
        /// <returns>The argument.</returns>
        public static Argument Argument(string name)
        {
            return new Argument(name);
        }

        /// <summary>Creates an argument that can be verified.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The argument value.</param>
        /// <returns>The argument constraint.</returns>
        public static ArgumentConstraint<T> Argument<T>(string name, T value)
        {
            return new ArgumentConstraint<T>(new Argument<T>(name, value));
        }
    }
}
