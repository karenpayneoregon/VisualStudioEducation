using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStrings_1
{
    class Program
    {
        /// <summary>
        /// Home
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            FindExample();
            Console.ReadLine();
        }

        static void FindExample()
        {
            string findName = "Mark";
            string[] names = new string[] {"Joe", "Mark","Anne"};
            if (names.Any(name => name == findName))
            {
                Console.WriteLine($"Found {findName}");
            }

            

        }

        /// <summary>
        /// Explicit assignment
        /// </summary>
        static void OldSchool()
        {
            string firstName = "Karen";
            string lastName = "Payne";

            Console.WriteLine(firstName + " " + lastName);
        }
        /// <summary>
        /// Implicit assignment
        /// </summary>
        static void CurrentConventions()
        {
            var firstName = "Karen";
            var lastName = "Payne";

            Console.WriteLine($"{firstName} {lastName}");

            

        }

        static void GenerateEvent()
        {
            var test = new Counter();
        }
    }

    class Counter
    {
        public event EventHandler ThresholdReached;

        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            handler?.Invoke(this, e);
        }

        // provide remaining implementation for the class
    }

}
