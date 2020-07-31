using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class ResidenceEntity : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual int ZipCode { get; set; }
        public virtual CountyEntity County { get; set; }
    }
}
