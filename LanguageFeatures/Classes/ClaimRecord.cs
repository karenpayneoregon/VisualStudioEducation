using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageFeatures.Builders;

namespace LanguageFeatures.Classes
{
    public class ClaimRecord
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        public string Ssn { get; set; }
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Invalid PIN")]
        public string Pin { get; set; }
        public char AllDoneCode { get; set; }
        public string Bye { get; set; }
        public double HoursWorked { get; set; }
        public string LanguageCode { get; set; }
        public string Question1A { get; set; }
        public string Question1B { get; set; }
        public string Question1C { get; set; }
        public string Question3A { get; set; }
        public string Question3B { get; set; }
        public string Question3C { get; set; }

        public ClaimRecord(ClaimRecordBuilder builder)
        {
            
        }

        public ClaimRecord()
        {
            
        }
    }
}
