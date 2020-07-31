using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class ResidenceListDTO : DTOBase
    {
        public int? ResidenceId { get; set; }
        public virtual ResidenceDTO Residence { get; set; }
        public int? Pre_BillId { get; set; }
        public virtual Pre_BillDTO Pre_Bill { get; set; }
    }
}
