using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class AcceptedLawDTO : DTOBase
    {
        public int? BillId { get; set; }
        public BillDTO Bill { get; set; }
    }
}
