using System;

namespace TeamLibrary.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; }
        DateTime ModifiedDate { get; }
        int ModifiedByUserId { get; }
    }
}
