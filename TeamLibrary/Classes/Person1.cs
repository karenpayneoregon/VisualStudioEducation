using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.Classes
{
    public class Person1
    {
        public int Identifier { get; set; }

        [Required(ErrorMessage = "Contact {0} is required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Contact {0} is required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        //[DataType(DataType.Time)]
        //[Range(typeof(TimeSpan), "00:00", "12:00")]
        //[DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        [Range(typeof(TimeSpan), "13:00", "23:59", ErrorMessage = "Time must be between 13:00 to 23:59")]
        //[RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)",ErrorMessage = "Time must be between 00:00 to 23:59")]
        public TimeSpan AllottedTime { get; set; }

    }
}
