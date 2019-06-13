using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using LanguageFeatures.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLibrary.BaseClasses;
using TeamLibrary.Classes;
using TeamLibrary.Enumerations;
using TeamLibrary.Extensions;
using TeamLibrary.Validators;
using VariousTest.BaseClasses;
using VariousTest.Traits;

namespace VariousTest
{
    [TestClass(), TestCategory("Validators")]
    public class ValidatorUnitTest : TestBase
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
        /// <summary>
        /// Validate the validator accepts a good instance of person
        /// </summary>
        [TestMethod]
        public void ValidatePersonGoodTest()
        {
            var validationResult = ValidationHelper.ValidateEntity(KarenPayne);
            Assert.IsFalse(validationResult.HasError,
                "Expected person to validate");

        }
        /// <summary>
        /// Validate the validator for first and last name works
        /// </summary>
        [TestMethod]
        public void ValidatePersonMissingFirstLastNameTest()
        {
            var expectedErrorMessages = new[]
            {
                "Contact FirstName is required",
                "Contact LastName is required"
            };

            var person = new Person()
            {
                BirthDate = new DateTime(1956, 9, 24)
            };

            var validationResult = ValidationHelper.ValidateEntity(person);

            Assert.IsTrue(
                expectedErrorMessages
                    .SequenceEqual(validationResult.Errors.Select(err => err.ErrorMessage)),
                "Expected two violations");

        }
        [TestMethod]
        [TestTraits(Trait.ValidatingSocialSecurity)]
        public void DisplayPersonSsnTest()
        {
            var person = new Person()
            {
                Ssn = "12345678".Replace("-",""),
                FirstName = "Karen",
                LastName = "Payne",
                BirthDate = new DateTime(1956, 9, 24)
            };

            var validationResult = ValidationHelper.ValidateEntity(person);
            
            Assert.IsTrue(validationResult.HasError,
                "Expected person not be valid, bad SSN");

        }
        /// <summary>
        /// Validate TimeSpan validation works as expected
        /// </summary>
        [TestMethod]
        public void TimeSpanBetweenTest()
        {
            var validationResult = ValidationHelper.ValidateEntity(PersonOne);
            Assert.IsTrue(validationResult.HasError);
            Assert.IsTrue(validationResult.Errors[0].ErrorMessage == "Time must be between 13:00 to 23:59");
        } 
        /// <summary>
        /// Validate SSN and PIN
        /// </summary>
        [TestMethod]
        public void ClaimRecordValidSsnAndPinTest()
        {
            var claimRecord = new ClaimRecord() {Ssn = "123456789", Pin = "1234"};
            var validationResult = ValidationHelper.ValidateEntity(claimRecord);

            Assert.IsTrue(validationResult.HasError == false, 
                "Expected good SSN and PIN");
        } 
        [TestMethod]
        public void ValidateListPropertyHasItemsTest()
        {
            var book = new Book()
            {
                Title = "One Giant Leap: The Impossible Mission That Flew Us to the Moon",
                ISBN = "10: 1501106295", Category =  BookCategory.Adventure,
                NotesList = new List<string>() { "Like page 5" }
            };

            var validationResult = ValidationHelper.ValidateEntity(book);

            Assert.IsTrue(validationResult.HasError == false,
                "Expected good book");
        }
        [TestMethod]
        public void ValidateEnumIsAssignedTest()
        {
            var book = new Book()
            {
                Title = "One Giant Leap: The Impossible Mission That Flew Us to the Moon",
                ISBN = "10: 1501106295",
                NotesList = new List<string>() { "Like page 5" }
            };

            var validationResult = ValidationHelper.ValidateEntity(book);

            Assert.IsTrue(validationResult.HasError && validationResult.Errors[0].ErrorMessage == "Category is required.",
                "Expected rule violation on category of book");
        } 
    }
}

