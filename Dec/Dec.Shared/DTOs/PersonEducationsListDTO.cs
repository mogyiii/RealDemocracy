using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class PersonEducationsListDTO : DTOBase
    {
        public int? PersonId { get; set; }
        public PersonDTO Person { get; set; }
        public int? EducationsId { get; set; }
        public EducationsDTO Educations { get; set; }
    }
}
