using System.Data.Common;
using System.Data.Entity;

namespace EntityEffortExample
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbConnection connection) : base(connection, false)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}