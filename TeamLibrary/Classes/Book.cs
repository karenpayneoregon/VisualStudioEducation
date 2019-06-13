using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLibrary.Validators.Rules;

namespace TeamLibrary.Classes
{
    public class Book
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ISBN { get; set; }

        [ListHasElements(ErrorMessage = "{0} must contain an element")]
        public List<string> NotesList { get; set; }
    }
}
