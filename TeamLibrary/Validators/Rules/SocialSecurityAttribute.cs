using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeamLibrary.Validators.Rules
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SocialSecurityAttribute : ValidationAttribute
    {
        public string SocialValue { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var test = value.ToString().Length;
            return Regex.IsMatch(value.ToString(), @"^\d{9}$");
        }
    }
}
