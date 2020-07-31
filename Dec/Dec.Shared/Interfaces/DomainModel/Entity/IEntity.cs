using System;

namespace Dec.Shared.Interfaces.DomainModel.Entity
{
    public interface IEntity
    {
        int Id { get; }

        DateTime CreationDateUTC { get; }

        DateTime ModificationDateUTC { get; }
    }
}
