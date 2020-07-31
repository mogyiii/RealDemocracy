using System;
using Dec.Common.Interfaces;

namespace Dec.DataAccess.Entities.Base
{
    public abstract class LogicalEntityBase : EntityBase, ILogicalDeletable
    {
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionDateUTC { get; set; }
    }
}
