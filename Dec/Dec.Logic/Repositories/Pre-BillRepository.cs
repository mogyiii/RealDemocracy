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
    public class Pre_BillRepository : RepositoryBase<Pre_BillEntity, Pre_BillDTO>, IPre_BillRepository
    {
        public Pre_BillRepository(ISession session, IMapper mapper) : base(session, mapper)
        {
        }
    }
}
