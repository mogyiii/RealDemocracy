using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Dec.Logic.Identity
{
    public class AppSignInManager : SignInManager<AppIdentityPerson>
    {
        private readonly AppIdentityPersonManager _identityUserManager;

        public AppSignInManager(AppIdentityPersonManager identityUserManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<AppIdentityPerson> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<AppIdentityPerson>> logger,
            IAuthenticationSchemeProvider schemes)
            : base(identityUserManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
            _identityUserManager = identityUserManager;
        }

        public override async Task SignInAsync(AppIdentityPerson user, bool isPersistent, string authenticationMethod = null)
        {
            await SignOutAsync();
            await base.SignInAsync(user, isPersistent, authenticationMethod);

            user.LastLoggedInUTC = DateTime.UtcNow;
            user.IsLastLoginPersistent = isPersistent;

            await _identityUserManager.UpdateAsync(user);
            await _identityUserManager.ResetAccessFailedCountAsync(user);
        }

        public override async Task<SignInResult> CheckPasswordSignInAsync(AppIdentityPerson user, string password, bool lockoutOnFailure)
        {
            var result = await base.CheckPasswordSignInAsync(user, password, lockoutOnFailure);

            if (result?.Succeeded != true)
            {
                user.LastAttemptUTC = DateTime.UtcNow;
                await _identityUserManager.AccessFailedAsync(user);
            }

            return result;
        }
    }
}
