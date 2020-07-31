using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class SignatoryListDTO : DTOBase
    {
        public int? PersonId { get; set; }
        public PersonDTO Person { get; set; }
        public int? Pre_BillId { get; set; }
        public Pre_BillDTO Pre_Bill { get; set; }
    }
}
