using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class SuperVisorsEntity : EntityBase
    {
        public virtual PersonEntity Person { get; set; }
        public virtual DateTime? ExpirationDateUTC { get; set; }
    }
}
