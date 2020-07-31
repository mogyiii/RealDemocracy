using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class VoteSuperVisorEntity : EntityBase
    {
        public virtual ApplySuperVisorEntity ApplySuperVisor { get; set; }
        public virtual string HashedKey { get; set; }
    }
}
