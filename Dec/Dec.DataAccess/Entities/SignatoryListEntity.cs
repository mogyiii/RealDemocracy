using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class SignatoryListEntity : EntityBase
    {
        public int? PersonId { get; set; }
        public virtual PersonEntity Person { get; set; }
        public int? Pre_BillId { get; set; }
        public virtual Pre_BillEntity Pre_Bill { get; set; }
    }
}
