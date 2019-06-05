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
            int customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();
            var customer = ops.GetCompanyByCustomerIdentifier(customerIdentifier);

            var comparer = new ObjectsComparer.Comparer<Company>();

            //Compare objects
            IEnumerable<Difference> differences;
            var isEqual = comparer.Compare(customer, AroundTheHorn, out differences);
            Assert.IsTrue(isEqual);
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
            int customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();
            var customer = ops.GetCompanyByCustomerIdentifier(customerIdentifier);
            //Assert.IsTrue(customer.Equals(AroundTheHorn));
            var customer1 = AroundTheHorn;
            customer1.FirstName = "Frank";

            var comparer = new ObjectsComparer.Comparer<Company>();

            //Compare objects
            IEnumerable<Difference> differences;
            var positiveCompare = comparer.Compare(customer, customer1, out differences);
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
