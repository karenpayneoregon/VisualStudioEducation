using System;
using System.ComponentModel.DataAnnotations;
using TeamLibrary.Validators.Rules;

namespace TeamLibrary.BaseClasses
{
    [Serializable]
    public partial class Person 
    {
        public int Identifier { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "Contact {0} is required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Contact {0} is required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Contact {0} is required")]
        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }
        

    }
}
