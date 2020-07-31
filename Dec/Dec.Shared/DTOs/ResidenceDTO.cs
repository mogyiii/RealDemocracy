using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class ResidenceDTO : DTOBase
    {
        public string Name { get; set; }
        public int ZipCode { get; set; }
        public int? CountyID { get; set; }
        public CountyDTO County { get; set; }
    }
}
