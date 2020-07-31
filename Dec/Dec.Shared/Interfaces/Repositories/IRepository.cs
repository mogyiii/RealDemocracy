using System.Collections.Generic;
using Dec.Shared.Interfaces.DomainModel.DTO;
using Dec.Shared.Interfaces.DomainModel.Entity;

namespace Dec.Shared.Interfaces.Repositories
{
    public interface IRepository<TEntity, TDTO>
        where TEntity : IEntity
        where TDTO : IDTO
    {
        TDTO Get(int id);

        TDTO[] Get(IEnumerable<int> ids);

        TDTO[] GetAll();
    }
}
