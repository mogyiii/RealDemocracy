using Dec.DataAccess.Entities.Base;

namespace Dec.DataAccess.Entities
{
    public class PersonClaimEntity : EntityBase
    {
        public virtual PersonEntity User { get; set; }

        public virtual string ClaimType { get; set; }

        public virtual string ClaimValue { get; set; }
    }
}
