using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLibrary.EntityFrameworkClasses;

namespace VariousTest
{
    [TestClass(), TestCategory("EF6")]
    public class EntityUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ops = new NorthWindDatabaseOperations();
            ops.Simple();
        }
    }
}
