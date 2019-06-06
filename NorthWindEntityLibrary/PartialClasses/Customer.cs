using System;
using SharedLibrary.Interfaces;
using static System.DateTime;

namespace NorthWindEntityLibrary
{
    public partial class Customer : IBaseEntity
    {
        public int Id => CustomerIdentifier;
        public int ModifiedByUserId => 0;

        // ReSharper disable once PossibleInvalidOperationException
        DateTime IBaseEntity.ModifiedDate => ModifiedDate.Value;
    }
    public partial class Contact : IBaseEntity
    {
        public int Id => ContactId;

        public DateTime ModifiedDate => Now;

        public int ModifiedByUserId => 0;
        public string Title { get; set; }
    }
}
