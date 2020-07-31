using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class CountyEntity : EntityBase
    {
        public virtual string Name { get; set; }
    }
}
