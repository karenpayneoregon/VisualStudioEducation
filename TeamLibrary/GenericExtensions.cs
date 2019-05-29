using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamLibrary
{
    /// <summary>
    /// Various generic language extension methods
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Determine if T is between lower and upper
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="actual">Value to determine if between lower and upper</param>
        /// <param name="lower">Lower of range</param>
        /// <param name="upper">Upper of range</param>
        /// <returns>True if in range, false if not in range</returns>
        /// <example>
        /// <code>
        /// var startDate = new DateTime(2018, 12, 2, 1, 12, 0);
        /// var endDate = new DateTime(2018, 12, 15, 1, 12, 0);
        /// var theDate = new DateTime(2018, 12, 13, 1, 12, 0);
        /// Assert.IsTrue(theDate.Between(startDate,endDate));
        /// </code>
        /// </example>
        public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
        }
        /// <summary>
        /// Adds a value uniquely to to a collection and returns a value whether the value was added or not.
        /// </summary>
        /// <typeparam name = "T">The generic collection value type</typeparam>
        /// <param name = "sender">The collection.</param>
        /// <param name = "pValue">The value to be added.</param>
        /// <returns>Indicates whether the value was added or not</returns>
        public static bool AddUnique<T>(this ICollection<T> sender, T pValue)
        {
            var alreadyHasValue = sender.Contains(pValue);
            if (!alreadyHasValue)
            {
                sender.Add(pValue);
            }
            return alreadyHasValue;
        }
        /// <summary>
        /// Provides distinct on a property
        /// </summary>
        /// <typeparam name="TSource">Type</typeparam>
        /// <typeparam name="TKey">Key</typeparam>
        /// <param name="sender">Source</param>
        /// <param name="pKeySelector">Condition</param>
        /// <returns>Distinct items</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> sender, Func<TSource, TKey> pKeySelector)
        {
            var hKeys = new HashSet<TKey>();
            return sender.Where((element) => hKeys.Add(pKeySelector(element)));
        }
        /// <summary>
        /// Creates a delimited string from TSource
        /// </summary>
        /// <typeparam name="TSource">Source</typeparam>
        /// <param name="sender">Source to flatten to delimited string</param>
        /// <param name="pDelimiter">Delimiter which defaults to a comma</param>
        /// <returns>Delimited string</returns>
        public static string ToDelimitedString<TSource>(this IEnumerable<TSource> sender, string pDelimiter = ",")
        {
            if (sender == null) throw new ArgumentNullException(nameof(sender));
            if (pDelimiter == null) throw new ArgumentNullException(nameof(pDelimiter));
            return ToDelimitedStringImplement(sender, pDelimiter, (sb, e) => sb.Append(e));
        }
        /// <summary>
        /// Implementation for ToDelimitedString which can be used by itself
        /// </summary>
        /// <typeparam name="T">Source</typeparam>
        /// <param name="sender">Source to flatten to delimited string</param>
        /// <param name="pDelimiter">Delimiter which defaults to a comma</param>
        /// <param name="pAppend">StringBuilder</param>
        /// <returns>Delimited string</returns>
        static string ToDelimitedStringImplement<T>(IEnumerable<T> sender, string pDelimiter, Func<StringBuilder, T, StringBuilder> pAppend)
        {
            var sb = new StringBuilder();
            var i = 0;

            foreach (var value in sender)
            {
                if (i++ > 0) sb.Append(pDelimiter);
                pAppend(sb, value);
            }

            return sb.ToString();
        }
    }
}