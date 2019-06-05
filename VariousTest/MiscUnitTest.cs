using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLibrary.BaseClasses;

namespace VariousTest
{
    [TestClass(), TestCategory("Miscellaneous")]
    public class MiscUnitTest
    {
        /// <summary>
        /// Test demonstration using Any to determine if an item is in this
        /// case both list.
        /// </summary>
        [TestMethod]
        public void UsingAny()
        {
            var customer1 = new Company() { FirstName = "Karen", LastName = "Payne" };
            var customer2 = new Company() { FirstName = "Mary", LastName = "Jackson" };

            var cust2 = new List<Company>() { customer1, customer2 };

            Assert.IsTrue(cust2.Any(cust => cust.FirstName == "Karen" && cust.LastName == "Payne"),
                "expected first and last name to match");

            cust2.RemoveAt(0);
            Assert.IsFalse(cust2.Any(cust => cust.FirstName == "Karen" && cust.LastName == "Payne"),
                "expected not to find a match");
        }
    }
}
