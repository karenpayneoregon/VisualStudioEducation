using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageFeatures.Builders;

namespace LanguageFeatures.Classes
{
    public class ClaimRecord
    {
        public int Id { get; set; }
        public string Ssn { get; set; }
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
    }
}
