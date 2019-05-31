using System;
using TeamLibrary.BaseClasses;
using TeamLibrary.Interfaces;

namespace TeamLibrary.Classes
{
    public class Person2 : Person, IBaseEntity
    {
        public int Id => Identifier;
        public DateTime ModifiedDate { get; set; }
        public int ModifiedByUserId { get; set; }

        public int Age => Convert.ToInt32(DateTime.UtcNow.Date.Year - BirthDate.Value.Year);



        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}
