using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LanguageFeatures.Classes;

namespace LanguageFeatures.Builders
{
    public class ClaimRecordBuilder
    {
        private string _Ssn { get; set; }

        public ClaimRecordBuilder Start()
        {
            /*
             * Any initialization would go here
             */

            return this;
        }

        public ClaimRecordBuilder SetSocialSecurityNumber(string pSSN)
        {
            _Ssn = pSSN.Replace("-","");
            return this;
        }

        private string _Pin { get; set; }

        public ClaimRecordBuilder SetPin(string pPin)
        {
            _Pin = pPin;
            return this;
        }
        private char _AllDoneCode { get; set; }

        public ClaimRecordBuilder SetAllDoneCode(char pAllDoneCode)
        {
            _AllDoneCode = pAllDoneCode;
            return this;
        }
        public string _LanguageCode { get; set; } 
        public ClaimRecordBuilder LanguageCode(SpokenLanguageCodes pLanguageCodes)
        {
            _LanguageCode = pLanguageCodes.ToString();
            return this;
        }

        public ClaimRecordBuilder IsDone()
        {
            _AllDoneCode = 'Y';
            return this;
        }

        public bool IsReady()
        {

            return IsValidate();
        }

        private bool IsValidate()
        {
            return true;
        }

        private double _HoursWorked { get; set; }

        public ClaimRecordBuilder SetHoursWorked(double pHoursWorked)
        {
            _HoursWorked = pHoursWorked;
            return this;
        }
        public ClaimRecord Build()
        {
            var claimRecord = new ClaimRecord(this)
            {
                AllDoneCode = _AllDoneCode,
                Ssn = _Ssn,
                Pin = _Pin,
                LanguageCode = _LanguageCode
            } ;
            
            return claimRecord;
        }

        public ClaimRecordBuilder(string ssn, string pin)
        {
            _Ssn = ssn;
            _Pin = pin;
        }

        public ClaimRecordBuilder()
        {
            
        }

        public void WriteRecord()
        {
            /*
             *
             * Write to database
             */
        }
    }
}
