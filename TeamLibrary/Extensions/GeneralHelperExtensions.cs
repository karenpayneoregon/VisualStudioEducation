using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.Extensions
{
    public static class GeneralHelperExtensions
    {
        public static string TimeSpanArrayToString(this TimeSpan[] sender)
        {
            return string.Join(",", sender);
        }
        public static string[] ToStringArray(this string sender, char separator = ',')
        {
            return sender.Split(separator);
        }
        /// <summary>
        /// Converts a string to a Nullable type as per T
        /// </summary>
        /// <typeparam name="T">Type to convert too</typeparam>
        /// <param name="sender">String to work from</param>
        /// <returns>Nullable of T</returns>
        /// <example>
        /// <code>
        /// Dim value = "12".ToNullable(Of Integer)
        /// If value.HasValue Then
        ///   - use value
        /// Else
        ///   - do not use value
        /// </code>
        /// </example>
        public static T? ToNullable<T>(this string sender) where T : struct
        {

            T? result = new T?();

            try
            {
                if (!(string.IsNullOrWhiteSpace(sender)))
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    // ReSharper disable once PossibleNullReferenceException
                    result = (T)converter.ConvertFrom(sender);

                }
            }
            catch
            {
                // don't care, caller should use HasValue before accessing the value.
            }

            return result;

        }

    }
}
