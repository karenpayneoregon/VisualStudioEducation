using System;
using System.Data;
using System.Diagnostics;

namespace TeamLibrary.Extensions
{
    public static class DataExtensions
    {
        public static void DisplayColumnDetails(this DataTable pDataTable)
        {
            foreach (DataColumn column in pDataTable.Columns)
            {
                Console.WriteLine($"{column.ColumnName} - {column.DataType}");
            }
        }
        /// <summary> 
        ///     Gets the record value cast as int or 0. 
        /// </summary> 
        /// <param name = "pReader">The data reader.</param> 
        /// <param name = "pField">The name of the record field.</param> 
        /// <returns>The record value</returns> 
        [DebuggerStepThrough]
        public static int GetInt32Safe(this IDataReader pReader, string pField)
        {
            return pReader.GetInt32Safe(pField, 0);
        }

        /// <summary> 
        ///     Gets the record value casted as int or the specified default value. 
        /// </summary> 
        /// <param name = "pReader">The data reader.</param> 
        /// <param name = "pField">The name of the record field.</param> 
        /// <param name = "pDefaultValue">The default value.</param> 
        /// <returns>The record value</returns> 
        [DebuggerStepThrough]
        public static int GetInt32Safe(this IDataReader pReader, string pField, int pDefaultValue)
        {

            var value = pReader[pField];
            return (((value is int) ? Convert.ToInt32((int)(value)) : pDefaultValue));

        }
        /// <summary> 
        /// Gets the record value cast as decimal or 0. 
        /// </summary> 
        /// <param name = "pReader">The data reader.</param> 
        /// <param name = "pField">The name of the record field.</param> 
        /// <returns>The record value</returns> 
        [DebuggerStepThrough]
        public static double GetDoubleSafe(this IDataReader pReader, string pField)
        {
            return pReader.GetDoubleSafe(pField, 0);
        }

        /// <summary> 
        /// Gets the record value casted as double or the specified default value. 
        /// </summary> 
        /// <param name = "pReader">The data reader.</param> 
        /// <param name = "pField">The name of the record field.</param> 
        /// <param name = "pDefaultValue">The default value.</param> 
        /// <returns>The record value</returns> 
        [DebuggerStepThrough]
        public static double GetDoubleSafe(this IDataReader pReader, string pField, long pDefaultValue)
        {

            var value = pReader[pField];
            return (((value is double) ? Convert.ToDouble(value) : pDefaultValue));

        }
        /// <summary> 
        ///     Gets the record value cast as DateTime or DateTime.MinValue. 
        /// </summary> 
        /// <param name = "pReader">The data reader.</param> 
        /// <param name = "pField">The name of the record field.</param> 
        /// <returns>The record value</returns> 
        [DebuggerStepThrough]
        public static DateTime GetDateTimeSafe(this IDataReader pReader, string pField)
        {

            return pReader.GetDateTimeSafe(pField, DateTime.MinValue);

        }

        /// <summary> 
        /// Gets the record value cast as DateTime or the specified default value. 
        /// </summary> 
        /// <param name = "pReader">The data reader.</param> 
        /// <param name = "pField">The name of the record field.</param> 
        /// <param name = "pDefaultValue">The default value.</param> 
        /// <returns>The record value</returns> 
        [DebuggerStepThrough]
        public static DateTime GetDateTimeSafe(this IDataReader pReader, string pField, DateTime pDefaultValue)
        {

            var value = pReader[pField];
            return (((value is DateTime) ? Convert.ToDateTime(value) : pDefaultValue));

        }
        [DebuggerStepThrough]
        public static string GetStringSafe(this IDataReader pReader, string pField)
        {

            return ((pReader[pField] is DBNull) ? null : pReader[pField].ToString());

        }
        [DebuggerStepThrough]
        public static string GetStringSafe(this string sender)
        {
            return string.IsNullOrWhiteSpace(sender) ? "" : sender;
        }

    }
}