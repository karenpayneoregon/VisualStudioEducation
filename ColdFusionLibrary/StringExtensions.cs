using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdFusionLibrary
{
    public static class StringExtensions
    {
        /// <summary>
        /// Mimic Cold Fusion BinaryEncode for string to hex
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string StringToHex(this string sender)
        {
            byte[] ba = Encoding.Default.GetBytes(sender);
            return BitConverter.ToString(ba).Replace("-","");
        }

        public static bool CompareIgnoreCase(this string sender, string value)
        {
            return string.Equals(sender, value, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Mimic Cold Fusion Compare
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Comparer(this string sender, string value)
        {
            return String.Compare(sender, value, StringComparison.InvariantCulture);
        }
        public static int Find(this string sender, string value)
        {
            return sender.IndexOf("the", StringComparison.Ordinal) + 1;
        }
        public static int FindNoCase(this string sender, string value)
        {
            return sender.IndexOf("the", StringComparison.CurrentCultureIgnoreCase) + 1;
        }

        public static string LJustify(this string sender, int length)
        {
            return sender.PadLeft(length);
        }

        public static double Val(this string sender)
        {

            var posItem = sender.Select((singleChar,index) => new {letter = singleChar, index = index}) 
                .FirstOrDefault(item => char.IsLetter(item.letter));

            /*
             * No characters, proceed to conversion
             */
            if (posItem == null)
            {
                if (double.TryParse(sender, out var onlyNumber))
                {
                    return onlyNumber;
                }

                return 0;
            }
            /*
             * Had at least one character
             */
            var value = sender.Substring(0, posItem.index);
            if (double.TryParse(value, out var result))
            {
                return result;
            }
            return 0;
        }
    }
}
