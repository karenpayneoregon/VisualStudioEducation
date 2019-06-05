using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLibrary.BaseClasses;
using TeamLibrary.EntityFrameworkClasses;
using VariousTest.BaseClasses;
using ObjectsComparer;
using VariousTest.Traits;

namespace VariousTest
{
    [TestClass(), TestCategory("EF6")]
    public class EntityUnitTest : TestBase
    {
        [TestMethod]
        public void CompareEntityObjectToLocalInstanceTest()
        {
            var customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();
            var customer = ops.GetCompanyByCustomerIdentifier(customerIdentifier);

            var comparer = new ObjectsComparer.Comparer<Company>();

            var isEqual = comparer.Compare(customer, AroundTheHorn, out var differences);
            Assert.IsTrue(isEqual);
        }
        [TestMethod]
        public void GetCompanyWithCountryByIdentifier()
        {
            var customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();
            var customer = ops.GetCompanyWithCountryByIdentifier(customerIdentifier);

            var customer1 = AroundTheHorn;
            customer1.CountryId = 19;
            customer1.Country = "UK";

            var comparer = new ObjectsComparer.Comparer<Company>();

            var isEqual = comparer.Compare(customer1, customer, out var differences);
            Assert.IsTrue(isEqual, 
                "expected customer country test to be the same");


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


    }
}
