using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class ResidenceListEntity : EntityBase
    {
        public virtual ResidenceEntity Residence { get; set; }
        public virtual Pre_BillEntity Pre_Bill { get; set; }
    }
}
