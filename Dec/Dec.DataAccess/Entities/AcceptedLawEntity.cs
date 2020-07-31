using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class AcceptedLawEntity : EntityBase
    {
        public virtual BillEntity Bill { get; set; }
    }
}
