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
       
        [Range(typeof(TimeSpan), "13:00", "23:59", ErrorMessage = "Time must be between 13:00 to 23:59")]
        public TimeSpan AllottedTime { get; set; }

    }
}
