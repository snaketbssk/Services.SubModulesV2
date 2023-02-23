using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities.Redis;
using Services.SubModules.LogicLayers.Models.Redis.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services.Entities.Redis
{
    public class RedisStorageCacheService : BaseStorageCacheService
    {
        public RedisStorageCacheService(IConnectionMultiplexer connectionMultiplexer)
            : base()
        {
        }
    }
}
