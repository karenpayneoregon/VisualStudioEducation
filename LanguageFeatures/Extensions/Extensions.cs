using System.Collections.Generic;
using System.Linq;

namespace LanguageFeatures.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<T> ToSelectionWith<T>(this IEnumerable<T> sequence, params T[] items)
        {
            return new SortedSet<T>(sequence.Concat(items));
        }
        public static T[] Add<T>(this T[] target, T item)
        {
            T[] result = new T[target.Length + 1];
            target.CopyTo(result, 0);
            result[target.Length] = item;
            return result;
        }
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> objects)
        {
            foreach (KeyValuePair<TKey, TValue> obj in objects)
            {
                if (dictionary.ContainsKey(obj.Key))
                    dictionary[obj.Key] = obj.Value;
                else
                    dictionary.Add(obj.Key, obj.Value);
            }
        }
    }
}