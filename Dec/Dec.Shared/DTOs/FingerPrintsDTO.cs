using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class FingerPrintsDTO : DTOBase
    {
        public int? PersonId { get; set; }
        public PersonDTO Person { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
    }
}
