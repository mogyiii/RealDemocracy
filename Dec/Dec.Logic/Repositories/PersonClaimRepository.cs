using AutoMapper;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using Dec.DataAccess.Entities;
using Dec.Logic.Interfaces.Repositories;
using Dec.Shared.DTOs;

namespace Dec.Logic.Repositories
{
    public class PersonClaimRepository : RepositoryBase<PersonClaimEntity, PersonClaimDTO>, IPersonClaimRepository
    {
        public PersonClaimRepository(ISession session, IMapper mapper) : base(session, mapper)
        { }

        public PersonClaimDTO[] GetByUserId(int userId)
        {
            var claims = _session.QueryOver<PersonClaimEntity>()
                .Where(x => x.User.Id == userId)
                .List();

            var dtos = _mapper.Map<IList<PersonClaimDTO>>(claims);
            return dtos.ToArray();
        }

        public PersonClaimDTO[] GetSpecificClaimsByUserId(int userId, string claimType, string claimValue)
        {
            var query = _session.QueryOver<PersonClaimEntity>()
                .Where(x => x.User.Id == userId);

            if (string.IsNullOrEmpty(claimType) == false)
                query = query.Where(x => x.ClaimType == claimType);

            if (string.IsNullOrEmpty(claimValue) == false)
                query = query.Where(x => x.ClaimValue == claimValue);

            var claims = query.List();

            var dtos = _mapper.Map<IList<PersonClaimDTO>>(claims);
            return dtos.ToArray();
        }
    }
}
