using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStrings_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }

        static void OldSchool()
        {
            string firstName = "Karen";
            string lastName = "Payne";

            Console.WriteLine(firstName + " " + lastName);

        }
        static void CurrentConventions()
        {
            var firstName = "Karen";
            var lastName = "Payne";

            Console.WriteLine($"{firstName} {lastName}");
        }
    }

}
