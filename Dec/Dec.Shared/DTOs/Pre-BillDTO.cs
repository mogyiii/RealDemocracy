using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class Pre_BillDTO : DTOBase
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Docs { get; set; }
        public DateTime? ExpireDateUTC { get; set; }
        public DateTime? EntryDateUTC { get; set; }
    }
}
