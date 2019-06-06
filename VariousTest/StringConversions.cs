using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLibrary.Extensions;
using VariousTest.BaseClasses;

namespace VariousTest
{
    [TestClass(), TestCategory("String to int")]
    public class StringConversions : TestBase
    {
        /// <summary>
        /// Given a string array where some elements can be converted to 
        /// Nullable Integer and some elements which can not be converted
        /// validate the extension method ToNullable
        /// </summary>
        [TestMethod]
        public void StringToNullableInteger_Successful()
        {
            int[] expected = { 2, 6, -1 };

            var nullableResults = StringArrayMixedTypesIntegers.Where(item => item.ToNullable<int>().HasValue) 
                // ReSharper disable once PossibleInvalidOperationException
                .Select(item => item.ToNullable<int>().Value) .ToList();


            Assert.IsTrue(nullableResults.SequenceEqual(expected));

        }
        [TestMethod()]
        public void NotAllElementsCanBeConvertedPreserveArray_Integer()
        {
            var results = StringArrayMixedTypesIntegers.ToIntegerPreserveArray();

            var expectedCount = 9;

            // expected count
            Assert.AreEqual(results.Count(), expectedCount, $"Expected only {expectedCount} elements could be converted");

            // check if values are as expected
            Assert.IsTrue(IntegerArrayValidator.SequenceEqual(results));

        }
        /// <summary>
        /// Given a string array with non-integer values, test obtaining
        /// indices of non-integer values. Note the resulting array is zero base.
        /// </summary>
        [TestMethod()]
        public void GetNonIntegerValuesInMixedTypeArray()
        {
            var results = StringArrayMixedTypesIntegers.GetNonIntegerIndexes();
            var expectedIndices = new[] { 1, 2, 4, 5, 6, 7 };

            Assert.IsTrue(expectedIndices.SequenceEqual(results));
        }
        /// <summary>
        /// Attempt to parse a string which can not be converted to an Integer.
        /// No assertion requires pass ExpectedException attributive.
        /// </summary>
        [TestMethod, ExpectedException(typeof(FormatException), "Integer.Parse expects an Integer, failed as expected.")]
        public void WhatHappensWhenValueIsNotIntegerNoFormatting_Integer()
        {
            var nonInteger = "A";
            var result = int.Parse(nonInteger);
        }

    }
}
