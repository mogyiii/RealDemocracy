using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Dec.Logic.Interfaces.Repositories;
using Dec.Shared.Enums;

namespace Dec.Logic.Identity
{
    public class AppIdentityPersonManager : UserManager<AppIdentityPerson>
    {
        private readonly CancellationToken _cancellationToken;
        private readonly IPersonClaimRepository _userClaimRepository;

        public AppIdentityPersonManager(IUserStore<AppIdentityPerson> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<AppIdentityPerson> passwordHasher,
            IEnumerable<IUserValidator<AppIdentityPerson>> userValidators,
            IEnumerable<IPasswordValidator<AppIdentityPerson>> passwordValidators,
            ILookupNormalizer keyNormalizer, AppIdentityErrorDescriber errors,
            IServiceProvider services, ILogger<UserManager<AppIdentityPerson>> logger,
            IPersonClaimRepository userClaimRepository)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _cancellationToken = services?.GetService<IHttpContextAccessor>()?.HttpContext?.RequestAborted ?? CancellationToken.None;
            _userClaimRepository = userClaimRepository;
        }

        protected override CancellationToken CancellationToken => _cancellationToken;

        public override async Task<IdentityResult> ResetPasswordAsync(AppIdentityPerson user, string token, string newPassword)
        {
            var result = await base.ResetPasswordAsync(user, token, newPassword);
            return result;
        }

        public override async Task<IdentityResult> ChangePasswordAsync(AppIdentityPerson user, string currentPassword, string newPassword)
        {
            var result = await base.ChangePasswordAsync(user, currentPassword, newPassword);
            return result;
        }

        public async Task ReplaceRoleClaims(AppIdentityPerson user, IList<Role> newRoles)
        {
            var userClaims = _userClaimRepository.GetSpecificClaimsByUserId(user.Id, ClaimTypes.Role);
            foreach (var userClaim in userClaims)
            {
                var claim = new AppIdentityPersonClaim
                {
                    UserId = user.Id,
                    ClaimType = userClaim.ClaimType,
                    ClaimValue = userClaim.ClaimValue
                }.ToClaim();
                await RemoveClaimAsync(user, claim);
            }

            foreach (var role in newRoles)
            {
                var claim = new AppIdentityPersonClaim
                {
                    UserId = user.Id,
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = role.ToString()
                }.ToClaim();
                await AddClaimAsync(user, claim);
            }
        }
    }
}
