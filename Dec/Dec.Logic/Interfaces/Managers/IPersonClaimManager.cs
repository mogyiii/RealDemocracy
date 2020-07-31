using Dec.DataAccess.Entities;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.Managers;

namespace Dec.Logic.Interfaces.Managers
{
    public interface IUserClaimManager : IManager<PersonClaimEntity, PersonClaimDTO>
    { }
}
