using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class ApplySuperVisorEntity : EntityBase
    {
        public virtual PersonEntity Person { get; set; }
    }
}
