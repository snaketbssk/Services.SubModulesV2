using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Redis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public abstract class BaseIdentityCacheService : IIdentityCacheService
    {
        public IRepositoryCache<string, UserRedis> User { get; private set; }

        protected BaseIdentityCacheService(IRepositoryCache<string, UserRedis> user)
        {
            User = user;
        }
    }
}
