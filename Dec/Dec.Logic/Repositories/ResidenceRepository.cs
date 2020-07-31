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
    public class ResidenceRepository : RepositoryBase<ResidenceEntity, ResidenceDTO>, IResidenceRepository
    {
        public ResidenceRepository(ISession session, IMapper mapper) : base(session, mapper)
        {
        }
    }
}
