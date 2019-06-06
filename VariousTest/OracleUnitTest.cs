using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OracleDataLibrary.DataClasses;
using VariousTest.Traits;

namespace VariousTest
{
    [TestClass(), TestCategory("Oracle OCS")]
    public class OracleUnitTest
    {
        /// <summary>
        /// Determine that a record can be read in dev environment.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.OracleDataProviderRead)]
        public void SimpleReadOperationTest()
        {
            var ops = new DataOperations();
            var record = ops.GetOcsMessage(952, "EN");
            /*
             * If there were exceptions this assert would fail
             */
            Assert.IsTrue(ops.IsSuccessFul,
                "expected to read OCS message record in dev");

            Assert.IsTrue(
                record.FormFieldName == "TRIED_3X" && 
                record.MessageText.Contains("You tried three times to enter your PIN."),
                "Failed to find OCS message record");
        }
    }
}
