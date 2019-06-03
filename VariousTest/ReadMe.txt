
DataAnnotation articles

https://www.codeproject.com/Articles/256183/DataAnnotations-Validation-for-Beginner
https://www.codeproject.com/Articles/1184173/DataAnnotations-in-Depth

Deep copy
https://www.ryadel.com/en/how-to-perform-deep-copy-clone-object-asp-net-c-sharp/
https://github.com/force-net/DeepCloner



In commented out code various ways to check SSN but not as good as regular expressions
using System;
using System.ComponentModel.DataAnnotations;
using TeamLibrary.Validators.Rules;

namespace TeamLibrary.BaseClasses
{
    [Serializable]
    public partial class Person 
    {
        public int Identifier { get; set; }

        //
        // Various ways to try, left here to explain
        //
        //https://www.codeproject.com/Articles/256183/DataAnnotations-Validation-for-Beginner
        //[SocialSecurity(SocialValue = ""), DataType(DataType.Text)]
        //[StringLength(9, MinimumLength = 9, ErrorMessage = "Invalid")]
        //[Required(ErrorMessage = "Contact {0} is required")]
        //[StringLength(9, MinimumLength = 9, ErrorMessage = "Invalid")]
        //public string SSN { get; set; }

        //[Required(ErrorMessage = "{0} is Required")]
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
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
