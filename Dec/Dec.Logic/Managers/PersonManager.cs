using AutoMapper;
using NHibernate;
using Dec.DataAccess.Entities;
using Dec.Logic.Interfaces.Managers;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.UnitOfWork;
using Dec.Shared.Transaction;

namespace Dec.Logic.Managers
{
    public class PersonManager : ManagerBase<PersonEntity, PersonDTO>, IPersonManager
    {
        public PersonManager(ISession session, IMapper mapper, IUnitOfWork unitOfWork) : base(session, mapper, unitOfWork)
        { }

        protected override TransactionResult ValidateSaving(PersonEntity entity)
        {
            var result = base.ValidateSaving(entity);
            
            if (string.IsNullOrEmpty(entity.Email))
            {
                result.ErrorMessages.Add(new TransactionErrorMessage
                {
                    IsPublic = true,
                    Message = "Email is required!"
                });
                result.Succeeded = false;
            }

            if (string.IsNullOrEmpty(entity.Name))
            {
                result.ErrorMessages.Add(new TransactionErrorMessage
                {
                    IsPublic = true,
                    Message = "Name is required!"
                });
                result.Succeeded = false;
            }

            return result;
        }
    }
}
