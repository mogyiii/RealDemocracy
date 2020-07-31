using System;

namespace Dec.Shared.Interfaces.DomainModel.DTO
{
    public interface IDTO
    {
        int Id { get; }

        DateTime CreationDateUTC { get; }

        DateTime ModificationDateUTC { get; }
    }
}
