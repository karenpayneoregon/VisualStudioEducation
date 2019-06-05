using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.BaseClasses
{
    /// <summary>
    /// Represents a partial Customer
    /// </summary>
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContactIdentifier { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }
        public override string ToString()
        {
            return $"{Id}, '{Name}'";
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <returns>
        /// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as Company;

            if (other == null)
            {
                return false;
            }

            if (FirstName != other.FirstName || LastName != other.LastName)
            {
                return false;
            }

            return true;
        }
    }
}
