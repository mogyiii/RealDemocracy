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
    public class ResidenceListRepository : RepositoryBase<ResidenceListEntity, ResidenceListDTO>, IResidenceListRepository
    {
        public ResidenceListRepository(ISession session, IMapper mapper) : base(session, mapper)
        {
        }
    }
}
