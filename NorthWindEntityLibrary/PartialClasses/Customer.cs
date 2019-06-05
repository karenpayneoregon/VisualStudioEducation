using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Interfaces;

namespace NorthWindEntityLibrary
{
    public partial class Customer : IBaseEntity
    {
        public int Id => CustomerIdentifier;
        public int ModifiedByUserId => 0;

        // ReSharper disable once PossibleInvalidOperationException
        DateTime IBaseEntity.ModifiedDate => ModifiedDate.Value;
    }
}
