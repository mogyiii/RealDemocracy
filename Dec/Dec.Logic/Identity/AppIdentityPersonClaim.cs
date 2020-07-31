using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Dec.Shared.Enums;

namespace Dec.Logic.Identity
{
    public class AppIdentityPersonClaim : IdentityUserClaim<int>
    {
        public AppIdentityPersonClaim()
        { }

        public AppIdentityPersonClaim(AppIdentityPerson identityUser, Role role)
        {
            UserId = identityUser.Id;
            ClaimType = ClaimTypes.Role;
            ClaimValue = role.ToString();
        }
    }
}
