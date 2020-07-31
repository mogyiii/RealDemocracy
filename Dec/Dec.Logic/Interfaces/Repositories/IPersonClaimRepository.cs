using Dec.DataAccess.Entities;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.Repositories;

namespace Dec.Logic.Interfaces.Repositories
{
    public interface IPersonClaimRepository : IRepository<PersonClaimEntity, PersonClaimDTO>
    {
        PersonClaimDTO[] GetByUserId(int userId);

        PersonClaimDTO[] GetSpecificClaimsByUserId(int userId, string claimType = null, string claimValue = null);
    }
}
