using Dec.DataAccess.Entities;
using Dec.Shared.DTOs;
using Dec.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Logic.Interfaces.Repositories
{
    public interface ICountyRepository : IRepository<CountyEntity, CountyDTO>
    {
    }
}
