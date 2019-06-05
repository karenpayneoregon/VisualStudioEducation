using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.BaseClasses
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return $"{Id}, '{Name}'";
        }
        public override bool Equals(object obj)
        {
            var other = obj as Company;

            if (other == null)
                return false;

            if (FirstName != other.FirstName || LastName != other.LastName)
                return false;

            return true;
        }
    }
}
