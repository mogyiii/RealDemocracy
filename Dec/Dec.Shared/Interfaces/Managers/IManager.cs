using System.Collections.Generic;
using Dec.Shared.Interfaces.DomainModel.DTO;
using Dec.Shared.Interfaces.DomainModel.Entity;
using Dec.Shared.Transaction;

namespace Dec.Shared.Interfaces.Managers
{
    public interface IManager<TEntity, TDTO>
        where TEntity : IEntity
        where TDTO : IDTO
    {
        TransactionResult Save(TDTO dto);

        TransactionResult Delete(int id);

        TransactionResult Delete(IEnumerable<int> ids);
    }
}
