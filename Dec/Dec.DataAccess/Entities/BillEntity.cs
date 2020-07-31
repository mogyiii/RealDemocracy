using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class BillEntity : EntityBase
    {
        public virtual Pre_BillEntity Pre_Bill { get; set; }
        public virtual DateTime? ExpireDate { get; set; }
    }
}
