using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamLibrary.Interfaces;

namespace TeamLibrary.Repositories
{
    public abstract class BaseEntity
    {
    }
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
