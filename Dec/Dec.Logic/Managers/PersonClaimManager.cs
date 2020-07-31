using AutoMapper;
using NHibernate;
using Dec.DataAccess.Entities;
using Dec.Logic.Interfaces.Managers;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.UnitOfWork;

namespace Dec.Logic.Managers
{
    public class PersonClaimManager : ManagerBase<PersonClaimEntity, PersonClaimDTO>, IUserClaimManager
    {
        public PersonClaimManager(ISession session, IMapper mapper, IUnitOfWork unitOfWork) : base(session, mapper, unitOfWork)
        { }
    }
}
