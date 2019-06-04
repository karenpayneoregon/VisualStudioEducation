using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamLibrary.BaseClasses;
using TeamLibrary.Classes;
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
            var expectedErrorMessages = new string[]
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
                SSN = "12345678".Replace("-",""),
                FirstName = "Karen",
                LastName = "Payne",
                BirthDate = new DateTime(1956, 9, 24)
            };

            var validationResult = ValidationHelper.ValidateEntity(person);
            
            Assert.IsTrue(validationResult.HasError,
                "Expected person not be valid, bad SSN");

        }
    }
}
