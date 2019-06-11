using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleEntityFrameworkExample;
using SimpleEntityFrameworkExampleUnitTestProject.BaseClasses;

namespace SimpleEntityFrameworkExampleUnitTestProject
{
    [TestClass(), TestCategory("EF6 - Simple")]
    public class UnitTest1 : TestBase
    {
        #region Customer name BAD
        [TestMethod]
        public void GetCustomerByIdentifierUnrealisticSuccessfulTest()
        {
            Assert.IsTrue(GetCustomerByIdentifier(4).CompanyName == "Around the Horn");
        }
        [TestMethod]
        public void GetCustomerByIdentifierUnrealisticFailedTest()
        {
            Assert.IsFalse(GetCustomerByIdentifier(4).CompanyName == "Around the Horn Once");
        }
        #endregion
        #region Custome name GOOD
        [TestMethod]
        public void GetCustomerByIdentifierBetterSuccessfulTest()
        {
            var customerIdentifier = 4;
            var expectedName = GetCustomerNameByIdentifierUsingDataProvider(customerIdentifier);
            var actualName = GetCustomerByIdentifier(4).CompanyName;

            // uncomment to break this test method
            //actualName = "Noo";

            Assert.IsTrue(expectedName == actualName,
                $"Expected --> '{expectedName}' to equal '{actualName}'");
        }
        /// <summary>
        /// Using ValueTuple return customer name or empty string which can be
        /// verified using the second variable in th ValueTuple
        /// </summary>
        [TestMethod]
        public void GetCustomerByIdentifierBetterSuccessfulValueTupleTest()
        {
            var customerIdentifier = 4;
            var (companyName, success) = GetCustomerNameByIdentifierUsingEntityFramework_2(customerIdentifier);
            Assert.IsTrue(success);
        }

        #endregion

        [TestMethod]
        public void GetAllProductsTest()
        {
            var includeKitchenSink = false;
            var result = GetAllProducts(includeKitchenSink);
            Console.WriteLine();
        } 

        [TestMethod]
        public void DbSetAttachTest() 
        {
            //https://www.entityframeworktutorial.net/EntityFramework5/attach-disconnected-entity-graph.aspx
        }
    }
}
