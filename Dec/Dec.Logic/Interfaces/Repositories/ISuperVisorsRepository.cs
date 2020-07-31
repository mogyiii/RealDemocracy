using Dec.DataAccess.Entities;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.Repositories;

namespace Dec.Logic.Interfaces.Repositories
{
    public interface ISuperVisorsRepository : IRepository<SuperVisorsEntity, SuperVisorsDTO>
    {
    }
}
