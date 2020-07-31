using System;


namespace Dec.Common.Interfaces
{
    public interface ILogicalDeletable 
    { 
        bool IsDeleted { get; set; }
        DateTime? DeletionDateUTC { get; set; } 
    }
}
