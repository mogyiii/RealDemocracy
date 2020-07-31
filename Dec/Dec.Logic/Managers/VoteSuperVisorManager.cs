﻿using AutoMapper;
using Dec.DataAccess.Entities;
using Dec.Logic.Interfaces.Managers;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.UnitOfWork;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Logic.Managers
{
    public class VoteSuperVisorManager : ManagerBase<VoteSuperVisorEntity, VoteSuperVisorDTO>, IVoteSuperVisorManager
    {
        public VoteSuperVisorManager(ISession session, IMapper mapper, IUnitOfWork unitOfWork) : base(session, mapper, unitOfWork)
        {
        }
    }
}
