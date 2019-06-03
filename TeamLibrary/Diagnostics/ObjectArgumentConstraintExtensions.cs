﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.Diagnostics
{
    public static class ObjectArgumentConstraintExtensions
    {
        #region IsNotNull

        /// <summary>Verifies an argument is not <see langword="null"/>.</summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The constraint.</returns>
        /// <exception cref="ArgumentNullException">The argument is <see langword="null"/>.</exception>
        public static AndArgumentConstraint<T> IsNotNull<T>(this ArgumentConstraint<T> source) where T : class
        {
            if (source.Argument.Value == null)
                throw new ArgumentNullException(source.Argument.Name);

            return new AndArgumentConstraint<T>(source);
        }

        /// <summary>Verifies an argument is not <see langword="null"/>.</summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageArgs">The message arguments.</param>
        /// <returns>The constraint.</returns>
        /// <exception cref="ArgumentNullException">The argument is <see langword="null"/>.</exception>
        public static AndArgumentConstraint<T> IsNotNull<T>(this ArgumentConstraint<T> source, string message, params object[] messageArgs) where T : class
        {
            if (source.Argument.Value == null)
                throw new ArgumentNullException(source.Argument.Name, String.Format(message, messageArgs));

            return new AndArgumentConstraint<T>(source);
        }
        #endregion

        #region IsNull

        /// <summary>Verifies an argument is <see langword="null"/>.</summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The constraint.</returns>
        /// <exception cref="ArgumentException">The argument is not <see langword="null"/>.</exception>
        public static AndArgumentConstraint<T> IsNull<T>(this ArgumentConstraint<T> source) where T : class
        {
            return IsNull(source, "Must be null.");
        }

        /// <summary>Verifies an argument is <see langword="null"/>.</summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageArgs">The message arguments.</param>
        /// <returns>The constraint.</returns>
        /// <exception cref="ArgumentException">The argument is not <see langword="null"/>.</exception>
        public static AndArgumentConstraint<T> IsNull<T>(this ArgumentConstraint<T> source, string message, params object[] messageArgs) where T : class
        {
            if (source.Argument.Value != null)
                throw new ArgumentException(String.Format(message, messageArgs), source.Argument.Name);

            return new AndArgumentConstraint<T>(source);
        }
        #endregion

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> self)
        {
            return (self == null) || !self.Any();
        }

        public static bool IsNullOrEmpty<T>(this T[] self)
        {
            return (self == null) || (self.Length < 1);
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> self)
        {
            return (self == null) || (self.Count < 1);
        }
    }
}
