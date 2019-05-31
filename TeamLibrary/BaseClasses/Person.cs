using System;
using System.ComponentModel.DataAnnotations;
using TeamLibrary.Validators.Rules;

namespace TeamLibrary.BaseClasses
{
    public class Person
    {
        public int Identifier { get; set; }
        //https://www.codeproject.com/Articles/256183/DataAnnotations-Validation-for-Beginner
        [SocialSecurity(SocialValue = "")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "Contact {0} is required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Contact {0} is required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Contact {0} is required")]
        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; } 
    }
}
