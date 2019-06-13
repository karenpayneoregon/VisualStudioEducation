using NorthWindEntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using BaseConnectionLibrary.ConnectionClasses;
using TeamLibrary.BaseClasses;
using TeamLibrary.Classes;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLibrary.Extensions;
using static System.String;

namespace VariousTest.BaseClasses
{
    public class TestBase : SqlServerConnection
    {
        /// <summary>
        /// Used to store information that is provided to unit tests.
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.testcontext?view=mstest-net-1.2.0
        /// </summary>
        protected TestContext TestContextInstance;
        public TestContext TestContext
        {
            get => TestContextInstance;
            set
            {
                TestContextInstance = value;
                TestResults.Add(TestContext);
            }
        }

        public static IList<TestContext> TestResults;

        public Company AroundTheHorn => new Company()
        {
            Id = 4,
            Name = "Around the Horn",
            FirstName = "Thomas",
            LastName = "Hardy",
            Title = "Sales Representative"
        } ;

        public Person1 PersonOne => new Person1()
        {
            FirstName = "Karen",
            LastName = "Payne",
            AllottedTime = "07:35".ToTimeSpan()
        };

        public Customer InsertCustomer()
        {
            var customer = new Customer
            {
                CompanyName = "Miata-land",
                ContactId = 86,
                ContactTypeIdentifier = 7,
                CountryIdentifier = 20
            };

            return customer;
        }
        
        /// <summary>
        /// Person object without SSN
        /// </summary>
        public Person KarenPayne => new Person() {FirstName = "Karen", LastName = "Payne", BirthDate = new DateTime(1956, 9, 24) };

        protected readonly string[] StringArrayMixedTypesIntegers = { "2", "4B", null, "6", "8A", "", "1.3", "Karen", "-1" };
        protected readonly int[] IntegerArrayValidator = { 2, 0, 0, 6, 0, 0, 0, 0, -1 };
        protected readonly string[] StringArrayAllIntegers = { "2", "4", "5", "6", "8", "12", "1", "99", "-1" };
        protected readonly string[] StringArrayMixedTypesDouble = { "2.4", "4.8'", null, "6.9", "[8.5]", "", "1.3", "Karen", "1" };
        protected readonly string[] StringArrayCurrencyDouble = { "2.4", "4.8'", null, "6.9", "[8.5]", "", "1.3", "Karen", "1" };
        protected readonly double[] DoubleArrayValidator = { 2.4, 0, 0, 6.9, 0, 0, 1.3, 0, 1 };
        protected readonly string[] StringArrayAllDoubles = { "2.6", "4.7", "5", "6", "8.98", "12", "1", "99.2", "-1" };

        /// <summary>
        /// Used to validate return value from a Entity Framework query
        /// </summary>
        /// <param name="pCountryCodeIdentifier"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CountCountry(int pCountryCodeIdentifier, [CallerMemberName]string name = "")
        {
            if (name != "CountWithoutLoadingData")
            {
                throw new Exception("Just for fun");
            }

            DatabaseServer = ".\\SQLEXPRESS";
            DefaultCatalog = "NorthWindAzureForInserts";

            var selectStatement =
                "SELECT  COUNT(Customers.CompanyName) " + 
                "FROM Countries " + 
                "INNER JOIN Customers ON Countries.CountryIdentifier = Customers.CountryIdentifier " + 
                $"WHERE (Countries.CountryIdentifier = {pCountryCodeIdentifier})";

            using (var cn = new SqlConnection {ConnectionString = ConnectionString})
            {
                using (var cmd = new SqlCommand {Connection = cn, CommandText = selectStatement})
                {
                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

        }
        protected void showComparison(string one, string two)
        {
            int compareLinguistic = Compare(one, two, StringComparison.InvariantCulture);
            int compareOrdinal = Compare(one, two, StringComparison.Ordinal);
            if (compareLinguistic < 0)
                Console.WriteLine($"<{one}> is less than <{two}> using invariant culture");
            else if (compareLinguistic > 0)
                Console.WriteLine($"<{one}> is greater than <{two}> using invariant culture");
            else
                Console.WriteLine($"<{one}> and <{two}> are equivalent in order using invariant culture");
            if (compareOrdinal < 0)
                Console.WriteLine($"<{one}> is less than <{two}> using ordinal comparison");
            else if (compareOrdinal > 0)
                Console.WriteLine($"<{one}> is greater than <{two}> using ordinal comparison");
            else
                Console.WriteLine($"<{one}> and <{two}> are equivalent in order using ordinal comparison");
        }
    }
}
