using Dec.Shared.DTOs.Base;

namespace Dec.Shared.DTOs
{
    public class PersonClaimDTO : DTOBase
    {
        public int? PersonId { get; set; }

        public PersonDTO Person { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}
