﻿using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class SuperVisorsDTO : DTOBase
    {
        public int? PersonId { get; set; }
        public PersonDTO Person { get; set; }
        public DateTime? ExpirationDateUTC { get; set; }
    }
}
