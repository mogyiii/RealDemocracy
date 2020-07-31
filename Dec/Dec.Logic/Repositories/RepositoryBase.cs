﻿using AutoMapper;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using Dec.Common.Interfaces;
using Dec.DataAccess.Entities.Base;
using Dec.Shared.DTOs.Base;
using Dec.Shared.Interfaces.DomainModel.DTO;
using Dec.Shared.Interfaces.DomainModel.Entity;
using Dec.Shared.Interfaces.Repositories;

namespace Dec.Logic.Repositories
{
    public abstract class RepositoryBase<TEntity, TDTO> : IRepository<TEntity, TDTO>
        where TEntity : EntityBase, IEntity, new()
        where TDTO : DTOBase, IDTO, new()
    {
        protected readonly ISession _session;
        protected readonly IMapper _mapper;

        public RepositoryBase(ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public TDTO Get(int id)
        {
            var entity = _session.Get<TEntity>(id);
            if(entity is ILogicalDeletable deletableentity && deletableentity.IsDeleted)
            {
                entity = null;
            }
            var dto = _mapper.Map<TDTO>(entity);
            return dto;
        }

        public TDTO[] Get(IEnumerable<int> ids)
        {
            var entities = new List<TEntity>();

            foreach (var id in ids)
            {
                var entity = _session.Get<TEntity>(id);
                if (entity is ILogicalDeletable deletableentity && deletableentity.IsDeleted)
                {
                    entity = null;
                }
                if (entity != null)
                    entities.Add(entity);
            }

            var dtos = _mapper.Map<IList<TDTO>>(entities);
            return dtos.ToArray();
        }

        public TDTO[] GetAll()
        {
            var query = _session.QueryOver<TEntity>();
            if (typeof(ILogicalDeletable).IsAssignableFrom(typeof(TEntity)))
            {
                query.Where(x => ((ILogicalDeletable)x).IsDeleted == false);
            }
            var entities = query.List();
            var dtos = _mapper.Map<IList<TDTO>>(entities);

            return dtos.ToArray();
        }
    }
}
