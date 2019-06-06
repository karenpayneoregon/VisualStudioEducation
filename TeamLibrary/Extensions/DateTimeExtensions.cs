using System;
using System.Globalization;

namespace TeamLibrary.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Compose date and time by providing values for each element
        /// </summary>
        /// <param name="day">Date to use</param>
        /// <param name="time">Time to use</param>
        /// <returns></returns>
        public static DateTime At(this DateTime day, TimeSpan time)
        {
            return (new DateTime(day.Year, day.Month, day.Day, 0, 0, 0)).Add(time);
        }
        /// <summary>
        /// Convert string to date time using various formats
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static DateTime ToDate(this string sender)
        {
            var formats = new[] { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "MM/dd/yyyy" };
            var dateValue = DateTime.MinValue;

            DateTime.TryParseExact(sender, formats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out dateValue);

            return dateValue;

        }
    }
}