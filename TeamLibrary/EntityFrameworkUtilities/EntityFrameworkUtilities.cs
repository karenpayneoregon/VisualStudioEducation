using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.EntityFrameworkUtilities
{
    public  class EntityFrameworkUtilities
    {
        /// <summary>
        /// Provides the ability to revert changes in a live DbContext, not disconnected context.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        public void UndoingChangesDbEntityPropertyLevel(DbContext context, object entity)
        {
            DbEntityEntry entry = context.Entry(entity);
            if (entry.State == EntityState.Added || entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Detached;
                return;
            }
            if (entry.State == EntityState.Deleted)
            {
                entry.Reload();
            }

            foreach (string propertyName in entry.OriginalValues.PropertyNames)
            {
                // Get and Set the Property value by the Property Name.   
                entry.Property(propertyName).CurrentValue = entry.Property(propertyName).OriginalValue;
            }
        }
    }
}
