using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class VoteEntity : EntityBase
    {
        public virtual BillEntity Bill { get; set; }
        public virtual VoteOpportunitiesEntity VoteOpportunities { get; set; }
        public virtual string HashedKey { get; set; }
    }
}
