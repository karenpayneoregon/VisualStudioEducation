using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamLibrary.Extensions
{
    /// <summary>
    /// Various generic language extension methods
    /// </summary>
    public static class ComparableExtensions
    {
        /// <summary>Determines if a value is between two values, inclusive.</summary>
        /// <param name="sender">The source value.</param>
        /// <param name="minimumValue">The minimum value.</param>
        /// <param name="maximumValue">The Maximum value.</param>
        /// <returns><see langword="true"/> if the value is between the two values, inclusive.</returns>
        public static bool Between<T>(this IComparable<T> sender, T minimumValue, T maximumValue)
        {
            return sender.CompareTo(minimumValue) >= 0 && sender.CompareTo(maximumValue) <= 0;
        }

        /// <summary>Determines if a value is between two values, exclusive.</summary>
        /// <param name="sender">The source value.</param>
        /// <param name="minimumValue">The minimum value.</param>
        /// <param name="maximumValue">The Maximum value.</param>
        /// <returns><see langword="true"/> if the value is between the two values, exclusive.</returns>
        public static bool BetweenExclusive<T>(this IComparable<T> sender, T minimumValue, T maximumValue)
        {
            return sender.CompareTo(minimumValue) > 0 && sender.CompareTo(maximumValue) < 0;
        }
    }
}