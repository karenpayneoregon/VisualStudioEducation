using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace TeamLibrary.Extensions
{
    /// <summary>
    /// Common string extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determine if string is empty
        /// </summary>
        /// <param name="sender">String to test if null or whitespace</param>
        /// <returns>true if empty or false if not empty</returns>
        [DebuggerStepThrough]
        public static bool IsNullOrWhiteSpace(this string sender) => string.IsNullOrWhiteSpace(sender);

        /// <summary>
        /// Is a valid SSN
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if valid, false if invalid SSN</returns>
        /// <remarks>
        ///
        /// https://www.codeproject.com/Articles/651609/Validating-Social-Security-Numbers-through-Regular
        /// 
        /// Handle some commonly encountered “fake” values or ones that might easily be forged in
        /// an area that might require a user to enter one.
        /// 
        /// ^                                       #Start of expression
        /// (?!\b(\d)\1+-(\d)\1+-(\d)\1+\b)         #Don't allow all matching digits for every field
        /// (?!123-45-6789|219-09-9999|078-05-1120) #Don't allow "123-45-6789", "219-09-9999" or "078-05-1120"
        /// (?!666|000|9\d{2})\d{3}                 #Don't allow the SSN to begin with 666, 000 or anything between 900-999
        /// -                                       #A dash (separating Area and Group numbers)
        /// (?!00)\d{2}                             #Don't allow the Group Number to be "00"
        /// -                                       #Another dash (separating Group and Serial numbers)
        /// (?!0{4})\d{4}                           #Don't allow last four digits to be "0000"
        /// $                                       #End of expression
        /// </remarks>
        [DebuggerStepThrough]
        public static bool IsValidSsnWithoutDashes(this string value) =>
            Regex.IsMatch(value.Replace("-", ""),
                @"^(?!\b(\d)\1+\b)(?!123456789|219099999|078051120)(?!666|000|9\d{2})\d{3}(?!00)\d{2}(?!0{4})\d{4}$");

        [DebuggerStepThrough]
        public static bool IsValidSsnSimple(this string value)
        {
            var regexItem = new Regex(@"^\d{9}$");
            var matcher = regexItem.Match(value);
            return matcher.Success;
        }

        /// <summary>
        /// Overload of the standard String.Contains method which provides case sensitivity.
        /// </summary>
        /// <param name="sender">String to search</param>
        /// <param name="pSubString">Sub string to match</param>
        /// <param name="pCaseInSensitive">Use case or ignore case</param>
        /// <returns>True if string is in sent string</returns>
        public static bool Contains(this string sender, string pSubString, bool pCaseInSensitive)
        {
            if (pCaseInSensitive)
            {
                return sender?.IndexOf(pSubString, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            else
            {
                return (bool)sender?.Contains(pSubString);
            }
        }

        #region These extensions may not be suitable for everyone
        /// <summary>
        /// Convert string value to int, if string is not a valid int return 0.
        /// </summary>
        /// <param name="sender">String to convert to Int32</param>
        /// <returns>An int</returns>
        public static int ToInt32(this string sender)
        {
            return sender.IsNullOrWhiteSpace() || (sender == null) || sender.IsNumeric() == false ? Convert.ToInt32(0) : Convert.ToInt32(sender);
        }
        /// <summary>
        /// Convert string value to int
        /// </summary>
        /// <param name="sender">String to convert to Int32</param>
        /// <param name="pThrowExceptionOnFailure">When set to true will throw a runtime exception while set to false will not throw a runtime exception</param>
        /// <returns>Int</returns>
        /// <remarks>
        /// An exception is thrown if conversion fails with pThrowExceptionIfFailed = true.
        /// </remarks> 
        public static int ToInt32(this string sender, bool pThrowExceptionOnFailure = false)
        {
            var valid = int.TryParse(sender, out var result);

            if (valid) return result;
            if (pThrowExceptionOnFailure)
            {
                throw new FormatException($"'{sender}' cannot be converted as int");
            }

            return result;
        }
        /// <summary>
        /// Convert string value to decimal, if string is not a valid decimal return 0.
        /// </summary>
        /// <param name="sender">String to convert to decimal</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this string sender)
        {
            return sender.IsNullOrWhiteSpace() || (sender == null) == true || sender.IsNumeric() == false ? 0 : Convert.ToDecimal(sender);
        }

        /// <summary>
        /// Convert string value to bool, if string is not a valid bool return false.
        /// </summary>
        /// <param name="value">String to convert to bool</param>
        /// <returns>Converted value or false if failed to convert to bool</returns>
        public static bool ToBoolean(this string value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Determine if string is numeric
        /// </summary>
        /// <param name="sender">String to test if numeric</param>
        /// <returns>True if numeric or false if not numeric</returns>
        /// <remarks>
        /// Does not handle currency symbol
        /// </remarks>
        public static bool IsNumeric(this string sender)
        {
            var regularExpression = new Regex("^-[0-9]+$|^[0-9,\\.]+$");

            return regularExpression.Match(sender).Success;
        }
        /// <summary>
        /// Alternate to determine if a string is numeric
        /// </summary>
        /// <param name="sender">String to test if numeric</param>
        /// <returns>True if numeric or false if not numeric</returns>
        /// <remarks>
        /// Does not handle currency symbol
        /// </remarks>
        public static bool IsNumeric1(this string sender) => sender.All(char.IsNumber);
        /// <summary>
        /// Alternate to determine if a string is numeric
        /// </summary>
        /// <param name="sender">String to test if numeric</param>
        /// <returns>True if numeric or false if not numeric</returns>
        /// <remarks>
        /// This one a far fetch 
        /// </remarks>
        public static bool IsNumeric2(this string sender)
        {
            return double.TryParse(sender, out double result);
        }
        /// <summary>
        /// Join string array with " and " as the last delimiter.
        /// </summary>
        /// <param name="sender">String array to convert to delimited string</param>
        /// <returns>Delimited string</returns>
        public static string JoinWithLastSeparator(this string[] sender)
        {
            return string.Join(", ", sender.Take(sender.Length - 1)) + ((((sender.Length <= 1) ? "" : " and ")) + sender.LastOrDefault());
        }
        /// <summary>
        /// Join string array with specified delimiter, " and " for the last delimiter
        /// </summary>
        /// <param name="sender">String array to convert to delimited string</param>
        /// <param name="pDelimiter">Delimiter to separate array items</param>
        /// <returns>Delimited string</returns>
        public static string JoinWithLastSeparator(this string[] sender, string pDelimiter)
        {
            return string.Join(pDelimiter + " ", sender.Take(sender.Length - 1)) + ((((sender.Length <= 1) ? "" : " and ")) + sender.LastOrDefault());
        }
        /// <summary>
        /// Join string array with specified delimiter and last delimiter
        /// </summary>
        /// <param name="sender">String array to convert to delimited string</param>
        /// <param name="pDelimiter">Delimiter to separate array items</param>
        /// <param name="pLastDelimiter">Token used for final delimiter</param>
        /// <returns>Delimited string</returns>
        public static string JoinWithLastSeparator(this string[] sender, string pDelimiter, string pLastDelimiter)
        {
            return string.Join(pDelimiter + " ", sender.Take(sender.Length - 1)) + ((((sender.Length <= 1) ? "" : pLastDelimiter)) + sender.LastOrDefault());
        }
        /// <summary>
        /// Given a string with upper and lower cased letters separate them before each upper cased characters
        /// </summary>
        /// <param name="sender">String to work against</param>
        /// <returns>String with spaces between upper-case letters</returns>
        public static string SplitCamelCase(this string sender)
        {
            return Regex.Replace(Regex.Replace(sender, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
        }

    }
}