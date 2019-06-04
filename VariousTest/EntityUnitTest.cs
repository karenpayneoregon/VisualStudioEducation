using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLibrary.BaseClasses;
using TeamLibrary.EntityFrameworkClasses;
using VariousTest.BaseClasses;

namespace VariousTest
{
    [TestClass(), TestCategory("EF6")]
    public class EntityUnitTest : TestBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            int customerIdentifier = 4;
            var ops = new NorthWindDatabaseOperations();
            var customer = ops.GetCompanyByCustomerIdentifier(customerIdentifier);
            Assert.IsTrue(customer.Equals(AroundTheHorn));

            var comparer = new Comparer<Company>();
        }
    }
}
