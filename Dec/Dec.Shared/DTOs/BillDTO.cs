using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class BillDTO : DTOBase
    {
        public int? Pre_BillId { get; set; }
        public Pre_BillDTO Pre_Bill { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
