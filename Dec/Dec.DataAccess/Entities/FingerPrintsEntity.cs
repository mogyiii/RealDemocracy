using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class FingerPrintsEntity : EntityBase
    {
        public virtual PersonEntity Person { get; set; }
        public virtual string Name { get; set; }
        public virtual string Hash { get; set; }
    }
}
