using Dec.DataAccess.Entities;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.Repositories;

namespace Dec.Logic.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<PersonEntity, PersonDTO>
    {
        PersonDTO FindByUserName(string normalizedUserName);

        PersonDTO[] GetByClaim(string claimType, string claimValue);
    }
}
