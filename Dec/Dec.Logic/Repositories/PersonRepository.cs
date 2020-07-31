using AutoMapper;
using NHibernate;
using NHibernate.SqlCommand;
using System.Collections.Generic;
using System.Linq;
using Dec.DataAccess.Entities;
using Dec.Logic.Interfaces.Repositories;
using Dec.Shared.DTOs;

namespace Dec.Logic.Repositories
{
    public class PersonRepository : RepositoryBase<PersonEntity, PersonDTO>, IPersonRepository
    {
        public PersonRepository(ISession session, IMapper mapper) : base(session, mapper)
        { }

        public PersonDTO FindByUserName(string normalizedUserName)
        {
            var user = _session.QueryOver<PersonEntity>()
                .Where(x => x.NormalizedUserName == normalizedUserName)
                .List()
                .FirstOrDefault();

            if (user == null)
                return null;

            var dto = _mapper.Map<PersonDTO>(user);
            return dto;
        }

        public PersonDTO[] GetByClaim(string claimType, string claimValue)
        {
            PersonEntity parentAlias = null;
            PersonClaimEntity claimAlias = null;

            var users = _session.QueryOver(() => parentAlias)
                .JoinEntityAlias(
                    () => claimAlias,
                    () => claimAlias.User.Id == parentAlias.Id,
                    JoinType.LeftOuterJoin)
                .Where(x => claimAlias.ClaimType == claimType && claimAlias.ClaimValue == claimValue)
                .List();

            var dtos = _mapper.Map<IList<PersonDTO>>(users);
            return dtos.ToArray()
                ;
        }
    }
}
