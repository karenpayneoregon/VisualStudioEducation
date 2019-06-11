using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertingStringToNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string item = "10";
            int itemValue = 0;
            if (int.TryParse(item, out itemValue))
            {
                Console.WriteLine($"'{item}' was converted to {itemValue}");
            }
            else
            {
                Console.WriteLine($"'{item}' was not converted, default value {itemValue}");
            }

            item = "K";

            if (int.TryParse(item, out itemValue))
            {
                Console.WriteLine($"'{item}' was converted to {itemValue}");
            }
            else
            {
                Console.WriteLine($"'{item}' was not converted, default value {itemValue}");
            }

            item = "10.3";

            if (int.TryParse(item, out var intValue1))
            {
                Console.WriteLine($"'{item}' was converted to {intValue1}");
            }
            else
            {
                Console.WriteLine($"'{item}' was not converted, default value {intValue1}");
            }

            if (decimal.TryParse(item, out var decValue))
            {
                Console.WriteLine($"'{item}' was converted to int {decimal.ToInt32(decValue)}");
            }
            else
            {
                Console.WriteLine($"'{item}' was not converted, default value {decValue}");
            }


            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static int ToInteger(this string sender)
        {
            return double.TryParse(sender, out var intResult) ? (int) intResult : 0;
        }
    }
}
