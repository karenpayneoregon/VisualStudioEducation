using System;
using System.Globalization;
using System.Linq;

namespace TeamLibrary.Extensions
{

    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Validate all elements in a string array can be converted to a 
        /// TimeSpan array
        /// </summary>
        /// <param name="sender">
        /// String Array with at least one element
        /// </param>
        /// <returns>
        /// True if all elements are valid TimeSpans, 
        /// False is at least one element is not a valid TimeSpan
        /// </returns>
        public static bool CanConvertToTimeSpanArray(this string[] sender)
        {
            TimeSpan testValue = new TimeSpan();
            return sender.All((input) => TimeSpan.TryParse(input, out testValue));
        }
        /// <summary>
        /// Convert a TimeSpan array to a String array
        /// </summary>
        /// <param name="sender">
        /// Integer array with one or more elements
        /// </param>
        /// <returns></returns>
        public static string[] TimeSpanArrayToStringArray(this TimeSpan[] sender)
        {
            return Array.ConvertAll(sender, (input) => {
                return input.ToString();
            });
        }
        /// <summary>
        /// Given a string array assumed to be all TimeSpan return
        /// only those elements which are TimeSpan. If the string
        /// array had five elements and only two elements could be
        /// converted the length of the returning array will be a
        /// length of 2.
        /// </summary>
        /// <param name="sender">
        /// String Array with at least one element
        /// </param>
        /// <returns></returns>
        public static TimeSpan[] ToTimeSpanArray(this string[] sender)
        {
            return Array.ConvertAll(sender, (input) => {
                var value = new TimeSpan();
                return new { IsTimeSpan = TimeSpan.TryParse(input, out value), Value = value };
            }).Where((result) => result.IsTimeSpan).Select((result) => result.Value).ToArray();
        }

        /// <summary>
        /// Given a string array assumed to be all TimeSpan return
        /// all elements no matter if they can be converted. If
        /// not convertible their value will default to 00:00:00
        /// </summary>
        /// <param name="sender">
        /// String Array with at least one element
        /// </param>
        /// <returns></returns>
        public static TimeSpan[] ToTimeSpanPreserveArray(this string[] sender)
        {
            return Array.ConvertAll(sender, (input) => {
                TimeSpan value = new TimeSpan();
                TimeSpan.TryParse(input, out value);
                return value;
            });
        }

        /// <summary>
        /// Convert TimeSpan into DateTime
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        /// <remarks>
        /// Intended to be used when the date part does not matter
        /// </remarks>
        public static DateTime ToDateTime(this TimeSpan sender)
        {
            return DateTime.ParseExact(sender.Formatted("hh:mm"), "H:mm", null, DateTimeStyles.None);
        }
        /// <summary>
        /// Format a TimeSpan with AM PM
        /// </summary>
        /// <param name="sender">TimeSpan to format</param>
        /// <param name="format">Optional format</param>
        /// <returns></returns>
        public static string Formatted(this TimeSpan sender, string format = "hh:mm tt")
        {
            return DateTime.Today.Add(sender).ToString(format);
        }
    }
}