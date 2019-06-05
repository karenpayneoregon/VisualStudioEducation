using System;

namespace SharedLibrary.Interfaces 
{
    public interface IBaseEntity
    {
        int Id { get; }
        DateTime ModifiedDate { get; }
        int ModifiedByUserId { get; }
    }
}
