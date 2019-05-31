using System;

namespace TeamLibrary.Classes
{
    public class Person1
    {
        public int Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        DateTime ModifiedDate { get; set; }
        int ModifiedByUserId { get; set; }
    }
}
