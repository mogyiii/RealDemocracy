using System;
using Dec.Shared.DTOs.Base;

namespace Dec.Shared.DTOs
{
    public class PersonDTO : DTOBase
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }
        //
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public int? ResidenceId { get; set; }
        public ResidenceDTO Residence { get; set; }
        public string IDNumber { get; set; }
        public string Gender { get; set; }
        //
        public DateTime? LastAttemptUTC { get; set; }

        public int AccessFailedCount { get; set; }

        public DateTime? LastLoggedInUTC { get; set; }

        public bool IsLastLoginPersistent { get; set; }

        public string SecurityStamp { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTime? LockoutEnd { get; set; }
    }
}
