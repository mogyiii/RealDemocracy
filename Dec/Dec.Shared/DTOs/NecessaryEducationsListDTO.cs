using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class NecessaryEducationsListDTO : DTOBase
    {
        public int? EducationsId { get; set; }
        public EducationsDTO Educations { get; set; }
        public int? Pre_BillId { get; set; }
        public Pre_BillDTO Pre_Bill { get; set; }
    }
}
