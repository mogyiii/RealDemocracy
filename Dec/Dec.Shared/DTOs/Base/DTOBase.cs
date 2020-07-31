using System;
using Dec.Shared.Interfaces.DomainModel.DTO;

namespace Dec.Shared.DTOs.Base
{
    public abstract class DTOBase : IDTO
    {
        public int Id { get; set; }

        public DateTime CreationDateUTC { get; set; }

        public DateTime ModificationDateUTC { get; set; }

        protected DTOBase()
        {
            CreationDateUTC = DateTime.UtcNow;
            ModificationDateUTC = DateTime.UtcNow;
        }
    }
}
