using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dec.Logic.Identity
{
    public class AppIdentityPerson : IdentityUser<int>
    {
        public string Name { get; set; }

        public DateTime? LastAttemptUTC { get; set; }

        public int Attempts { get; set; }

        public DateTime? LastLoggedInUTC { get; set; }

        public bool IsLastLoginPersistent { get; set; }

        public IList<AppIdentityPersonClaim> UserClaims { get; set; }
    }
}
