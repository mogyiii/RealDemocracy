using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class VoteDTO : DTOBase
    {
        public int? BillId { get; set; }
        public BillDTO Bill { get; set; }
        public int? VoteOpportunitiesId { get; set; }
        public VoteOpportunitiesDTO VoteOpportunities { get; set; }
        public virtual string HashedKey { get; set; }
    }
}
