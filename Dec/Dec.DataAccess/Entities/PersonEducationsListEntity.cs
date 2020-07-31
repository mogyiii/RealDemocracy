using Dec.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.DataAccess.Entities
{
    public class PersonEducationsListEntity : EntityBase
    {
        public virtual PersonEntity Person { get; set; }
        public virtual EducationsEntity Educations { get; set; }
    }
}
