using System;
using SharedLibrary.Interfaces;
using TeamLibrary.Interfaces;

namespace TeamLibrary.Classes
{
    public class AuditLog : IBaseEntity
    {
        public long AuditLogId { get; set; }
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public DateTime DateStamp { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }

        /*
         * Implements IBaseEntity
         */
        public int Id => (int)AuditLogId;
        public DateTime ModifiedDate => DateStamp;
        public int ModifiedByUserId => UserId;

    }

}
