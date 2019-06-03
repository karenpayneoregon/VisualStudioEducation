using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLibrary.Diagnostics;

namespace TeamLibrary.Extensions
{
    public static class CollectionExtensions
    {
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
        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            Verify.Argument(nameof(items)).WithValue(items).IsNotNull();

            if (!items.IsNullOrEmpty())
            {
                foreach (var item in items)
                    source.Add(item);
            };
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
            var index = 0;

            foreach (var value in sender)
            {
                if (index++ > 0) sb.Append(pDelimiter);
                pAppend(sb, value);
            }

            return sb.ToString();
        }

    }
}
