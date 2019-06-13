using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLibrary.Extensions;

namespace TeamLibrary.Validators.Rules
{
    public class ListHasElements : ValidationAttribute
    {
        public override bool IsValid(object sender)
        {
            if (sender == null)
            {
                return false;
            }

            if (sender.IsList())
            {
                var result = ((IEnumerable)sender).Cast<object>().ToList();
                return result.Any();
            }
            else
            {
                return false;
            }
        }
    }
}
