using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLibrary.BaseClasses;
using TeamLibrary.EntityFrameworkClasses;
using VariousTest.BaseClasses;
using ObjectsComparer;
using VariousTest.Traits;

namespace VariousTest
{
    [TestClass(), TestCategory("SQL-Server EF6")]
    public class EntityUnitTest : TestBase
    {
        [TestMethod]
        public void CompareEntityObjectToLocalInstanceTest()
        {
            var customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();

            /*
             * Return specific properties
             */
            var customer = ops.GetCompanyByCustomerIdentifier(customerIdentifier);

            var comparer = new ObjectsComparer.Comparer<Company>();

            var isEqual = comparer.Compare(customer, AroundTheHorn, out var differences);
            Assert.IsTrue(isEqual);

            /*
             * Demonstrate returning all navigation properties
             */
            ops.GetCompanyByCustomerIdentifierTemp(customerIdentifier);

        }
        /// <summary>
        /// Note a real test but a entry point to demo lazying loading.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.EntityFrameworkLazingEager)]
        public void GetCompanyWithCountryByIdentifier_EagerLoading()
        {
            var customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();
            ops.GetCompanyByCustomerIdentifierEager(customerIdentifier);
        } 
        [TestMethod]
        public void CountWithoutLoadingData()
        { 
            var countryIdentifier = 19;
            var ops = new NorthWindDatabaseOperations();
            var countryCountEntityFramework  = ops.CountryCountForCustomers(countryIdentifier);
            var countryCountSqlClient = CountCountry(countryIdentifier);

            Assert.IsTrue(countryCountSqlClient == countryCountEntityFramework,
                "Expected same count between EF and SqlClient");
        } 
        [TestMethod]
        public void GetCompanyWithCountryByIdentifier()
        {
            var customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();
            var customer = ops.GetCompanyWithCountryByIdentifier(customerIdentifier);

            var customer1 = AroundTheHorn;
            customer1.ContactIdentifier = 4;
            customer1.CountryId = 19;
            customer1.Country = "UK";

            var comparer = new ObjectsComparer.Comparer<Company>();

            var isEqual = comparer.Compare(customer1, customer, out var differences);
            Assert.IsTrue(isEqual,
                "expected customer country test to be the same");

        }
        /// <summary>
        /// This shows how to test an update using a detached entity.
        /// A well coded test would use mocked data or live data where
        /// live data would automatically be reset. See Karen's example
        /// https://code.msdn.microsoft.com/C-Entity-Framework-6-unit-f5a12725?redir=0
        /// </summary>
        [TestMethod]
        public void UpdateCustomerContactFirstLastNameTest()
        {
            var company = new Company() { ContactIdentifier = 4, FirstName = "Karen", LastName = "Payne" };
            var ops = new NorthWindDatabaseOperations();
            Assert.IsTrue(ops.UpdateCompanyContactFirstLastName(company));
            company.FirstName = "Thomas";
            company.LastName = "Hardy";
            Assert.IsTrue(ops.UpdateCompanyContactFirstLastName(company));

        }
        [TestMethod]
        [Ignore]
        public void InsertNewCustomerTest()
        {
            var ops = new NorthWindDatabaseOperations();
            Assert.IsTrue(ops.InsertCustomer(InsertCustomer()));

        }
        /// <summary>
        /// Test ObjectsComparer functionality
        /// </summary>
        /// <remarks>
        /// https://www.codeproject.com/Articles/1212996/Using-Objects-Comparer-to-Compare-Complex-Objects
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.ObjectsComparer)]
        public void ObjectsComparerValueMismatchTest()
        {
            var customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();
            var customer = ops.GetCompanyByCustomerIdentifier(customerIdentifier);
            //Assert.IsTrue(customer.Equals(AroundTheHorn));
            var customer1 = AroundTheHorn;
            customer1.FirstName = "Frank";

            var comparer = new ObjectsComparer.Comparer<Company>();

            var positiveCompare = comparer.Compare(customer, customer1, out var differences);
            Assert.IsFalse(positiveCompare);

            var diff = differences.FirstOrDefault();
            Assert.IsTrue(diff != null && diff.DifferenceType == DifferenceTypes.ValueMismatch,
                "expected ValueMismatch");
            Assert.IsTrue(diff.MemberPath == "FirstName",
                "expected first name");

            Assert.IsTrue(diff.Value1 == "Thomas",
                "expected Thomas");

            Assert.IsTrue(diff.Value2 == "Frank",
                "expected Frank");

        }

        [TestMethod]
        public void GetCompanyWithCountryByIdentifierSqlClient()
        {
            var customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();
            ops.GetCustomersByCustomerIdentifierSqlClientDataProvider(customerIdentifier);

        }
    }
}
