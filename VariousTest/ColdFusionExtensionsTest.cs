using System;
using System.Collections.Generic;
using ColdFusionLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VariousTest.BaseClasses;

namespace VariousTest
{
    [TestClass(), TestCategory("Cold Fusion")]
    public class ColdFusionExtensionsTest : TestBase
    {
        /// <summary>
        /// Demonstration to show how to get the current executing test method
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            Console.WriteLine(TestContext.TestName);
        }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
        [TestMethod]
        public void StringToHexTest()
        {
            var item = "GoodMorning! What's Up?";
            var result = item.StringToHex();
            Console.WriteLine(result);
        }
        [TestMethod]
        public void StringCompareTest()
        {
            var value1 = "This is a simple test";
            var value2 = "This IS a simple test";

            var result1 = string.Equals(value1, value2);
            var result2 = value1.CompareIgnoreCase(value2);

            Console.WriteLine($"{result1} {result2}");

            string first = "Sie tanzen auf der Straße.";
            string second = "Sie tanzen auf der Strasse.";

            var result3 = first.Comparer(second);
            Console.WriteLine(result3);

            //
        }
        /// <summary>
        /// Extension method to mirror Find and FindNoCase
        /// </summary>
        [TestMethod]
        public void FindInStringTest()
        {
            var item = "The quick brown fox jumped over the lazy dog.";
            var result = item.Find("the");
            Console.WriteLine(result);

            result = item.FindNoCase("the");
            Console.WriteLine(result);
        }

        [TestMethod]
        public void LJustifyTest()
        {
            var item = "12345";
            var result = item.LJustify(10);
            Console.WriteLine($"'{result}' - {result.Length}");
        }
        [TestMethod]
        public void ValTest()
        {
            var item = "145Karen";
            Console.WriteLine(item.Val());

            item = "Karen111";
            Console.WriteLine(item.Val());

            item = "111";
            Console.WriteLine(item.Val());
        }
    }
}
