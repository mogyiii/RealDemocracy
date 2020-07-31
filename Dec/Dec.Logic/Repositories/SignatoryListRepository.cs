using AutoMapper;
using Dec.DataAccess.Entities;
using Dec.Logic.Interfaces.Repositories;
using Dec.Shared.DTOs;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Logic.Repositories
{
    public class SignatoryListRepository : RepositoryBase<SignatoryListEntity, SignatoryListDTO>, ISignatoryListRepository
    {
        public SignatoryListRepository(ISession session, IMapper mapper) : base(session, mapper)
        {
        }
    }
}
