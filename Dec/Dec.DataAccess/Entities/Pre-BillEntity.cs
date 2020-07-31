using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class Pre_BillEntity : EntityBase
    {
        public virtual string Title { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string Docs { get; set; }
        public virtual DateTime? ExpireDateUTC { get; set; }
        public virtual DateTime? EntryDateUTC { get; set; }
    }
}
