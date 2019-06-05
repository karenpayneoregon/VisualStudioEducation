using System;
using SharedLibrary.Interfaces;
using TeamLibrary.Interfaces;

namespace TeamLibrary.BaseClasses 
{
    public partial class Person :  IBaseEntity, ICloneable
    {
        public int Id => Identifier;
        public DateTime ModifiedDate { get; set; }
        public int ModifiedByUserId { get; set; }

        // ReSharper disable once PossibleInvalidOperationException
        public int Age => Convert.ToInt32(DateTime.UtcNow.Date.Year - BirthDate.Value.Year);

        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}
