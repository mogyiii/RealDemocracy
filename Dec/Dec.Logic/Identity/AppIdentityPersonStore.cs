using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Dec.Logic.Interfaces.Managers;
using Dec.Logic.Interfaces.Repositories;
using Dec.Shared.DTOs;
using Dec.Shared.Enums;

namespace Dec.Logic.Identity
{
    public class AppIdentityPersonStore : UserStoreBase<AppIdentityPerson, int, AppIdentityPersonClaim, IdentityUserLogin<int>, IdentityUserToken<int>>
    {
        private readonly IPersonManager _userManager;
        private readonly IPersonRepository _userRepository;
        private readonly IUserClaimManager _userClaimManager;
        private readonly IPersonClaimRepository _userClaimRepository;
        private readonly IMapper _mapper;

        public AppIdentityPersonStore(
            AppIdentityErrorDescriber describer,
            IPersonManager userManager,
            IPersonRepository userRepository,
            IUserClaimManager userClaimManager,
            IPersonClaimRepository userClaimRepository,
            IMapper mapper)
            : base(describer)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _userClaimManager = userClaimManager;
            _userClaimRepository = userClaimRepository;
            _mapper = mapper;
        }

        #region User Management

        public override IQueryable<AppIdentityPerson> Users => _userRepository.GetAll().Select(_mapper.Map<AppIdentityPerson>).ToList().AsQueryable();

        public override async Task<IdentityResult> CreateAsync(AppIdentityPerson identityUser, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));

            identityUser.UserName = identityUser.Email;

            var newUser = new PersonDTO();
            _mapper.Map(identityUser, newUser);

            var result = _userManager.Save(newUser);

            if (!result.Succeeded)
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "user_save_error",
                    Description = "Couldn't save User."
                });

            newUser.Id = result.Id.Value;
            _mapper.Map(newUser, identityUser);

            var claims = new List<Claim>
            {
                new AppIdentityPersonClaim(identityUser, Role.User).ToClaim(),
                new AppIdentityPersonClaim
                {
                    UserId = identityUser.Id,
                    ClaimType = "UserId",
                    ClaimValue = identityUser.Id.ToString()
                }.ToClaim()
            };

            await AddClaimsAsync(identityUser, claims, cancellationToken);

            return IdentityResult.Success;
        }

        public override Task<IdentityResult> DeleteAsync(AppIdentityPerson identityUser, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            _userManager.Delete(identityUser.Id);

            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<AppIdentityPerson> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            var user = _userRepository.Get(int.Parse(userId));
            return Task.FromResult(_mapper.Map<AppIdentityPerson>(user));
        }

        public override Task<AppIdentityPerson> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            var user = _userRepository.FindByUserName(normalizedUserName);
            return Task.FromResult(_mapper.Map<AppIdentityPerson>(user));
        }

        public override Task<AppIdentityPerson> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return FindByNameAsync(normalizedEmail, cancellationToken);
        }

        protected override Task<AppIdentityPerson> FindUserAsync(int userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            var user = _userRepository.Get(userId);
            return Task.FromResult(_mapper.Map<AppIdentityPerson>(user));
        }

        public override Task<string> GetNormalizedUserNameAsync(AppIdentityPerson identityUser, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            return Task.FromResult(identityUser.NormalizedUserName);
        }

        public override Task<string> GetUserIdAsync(AppIdentityPerson identityUser, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            return Task.FromResult(identityUser.Id.ToString());
        }

        public override Task<string> GetUserNameAsync(AppIdentityPerson identityUser, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            return Task.FromResult(identityUser.UserName);
        }

        public override Task SetNormalizedUserNameAsync(AppIdentityPerson identityUser, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            return Task.FromResult(identityUser.NormalizedUserName = normalizedName);
        }

        public override Task SetUserNameAsync(AppIdentityPerson identityUser, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            return Task.FromResult(identityUser.UserName = userName);
        }

        public override Task<IdentityResult> UpdateAsync(AppIdentityPerson identityUser, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            var user = identityUser.Id > 0
                ? _userRepository.Get(identityUser.Id)
                : new PersonDTO();
            _mapper.Map(identityUser, user);

            _userManager.Save(user);

            return Task.FromResult(IdentityResult.Success);
        }
        #endregion

        #region Password Management
        public override Task<string> GetPasswordHashAsync(AppIdentityPerson identityUser, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            return Task.FromResult(identityUser.PasswordHash);
        }

        public override Task<bool> HasPasswordAsync(AppIdentityPerson identityUser, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            return Task.FromResult(!string.IsNullOrEmpty(identityUser.PasswordHash) && string.IsNullOrWhiteSpace(identityUser.PasswordHash) && identityUser.PasswordHash.Length > 0);
        }

        public override Task SetPasswordHashAsync(AppIdentityPerson identityUser, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            return Task.FromResult(identityUser.PasswordHash = passwordHash);
        }
        #endregion

        #region Claim Management
        public override Task<IList<Claim>> GetClaimsAsync(AppIdentityPerson identityUser, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }

            var claims = _userClaimRepository.GetByUserId(identityUser.Id)
                .Select(_mapper.Map<AppIdentityPersonClaim>)
                .Select(x => x.ToClaim())
                .ToList() as IList<Claim>;

            return Task.FromResult(claims);
        }

        public override Task AddClaimsAsync(AppIdentityPerson identityUser, IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }
            if (claims == null)
            {
                throw new ArgumentNullException(nameof(claims));
            }

            var user = _userRepository.Get(identityUser.Id);
            if (user == null)
            {
                return Task.FromResult(IdentityResult.Failed(
                    new IdentityError { Code = "user_not_found", Description = $"Cannot find User with id {user.Id}!" }));
            }

            foreach (var claim in claims)
            {
                var existingClaims = _userClaimRepository.GetSpecificClaimsByUserId(identityUser.Id, claim.Type, claim.Value);
                if (existingClaims.Length == 0)
                {
                    var newClaim = CreateUserClaim(identityUser, claim);
                    var userClaim = _mapper.Map<PersonClaimDTO>(newClaim);
                    userClaim.Id = 0;
                    userClaim.PersonId = user.Id;
                    _userClaimManager.Save(userClaim);
                }
            }

            return Task.FromResult(IdentityResult.Success);
        }

        public override Task ReplaceClaimAsync(AppIdentityPerson identityUser, Claim claim, Claim newClaim, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }
            if (newClaim == null)
            {
                throw new ArgumentNullException(nameof(newClaim));
            }

            var matchedClaims = _userClaimRepository.GetSpecificClaimsByUserId(identityUser.Id, claim.Type, claim.Value);

            foreach (var matchedClaim in matchedClaims)
            {
                matchedClaim.ClaimType = newClaim.Type;
                matchedClaim.ClaimValue = newClaim.Value;
                _userClaimManager.Save(matchedClaim);
            }

            return Task.FromResult(IdentityResult.Success);
        }

        public override Task RemoveClaimsAsync(AppIdentityPerson identityUser, IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (identityUser == null)
            {
                throw new ArgumentNullException(nameof(identityUser));
            }
            if (claims == null)
            {
                throw new ArgumentNullException(nameof(claims));
            }

            foreach (var claim in claims)
            {
                var userClaims = _userClaimRepository.GetSpecificClaimsByUserId(identityUser.Id, claim.Type, claim.Value);
                foreach (var userClaim in userClaims)
                {
                    _userClaimManager.Delete(userClaim.Id);
                }
            }

            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IList<AppIdentityPerson>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }

            var users = _userRepository.GetByClaim(claim.Type, claim.Value);
            return Task.FromResult(_mapper.Map<IList<AppIdentityPerson>>(users));
        }
        #endregion

        #region External Login Management
        protected override Task<IdentityUserLogin<int>> FindUserLoginAsync(int userId, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IdentityUserLogin<int>> FindUserLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task AddLoginAsync(AppIdentityPerson user, UserLoginInfo login, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task RemoveLoginAsync(AppIdentityPerson user, string loginProvider, string providerKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<UserLoginInfo>> GetLoginsAsync(AppIdentityPerson user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Token Management
        protected override Task<IdentityUserToken<int>> FindTokenAsync(AppIdentityPerson user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task AddUserTokenAsync(IdentityUserToken<int> token)
        {
            throw new NotImplementedException();
        }

        protected override Task RemoveUserTokenAsync(IdentityUserToken<int> token)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
