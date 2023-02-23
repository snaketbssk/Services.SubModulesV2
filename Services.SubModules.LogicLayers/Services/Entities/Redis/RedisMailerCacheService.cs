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
    public class RedisMailerCacheService : BaseMailerCacheService
    {
        public RedisMailerCacheService(IConnectionMultiplexer connectionMultiplexer)
            : base(outgoing: new RedisValueRepositoryCache<bool>(connectionMultiplexer, CacheConstant.MAILER_PROJECT, CacheConstant.OUTGOING_CONTAINER, TimeSpan.FromMinutes(1)))
        {
        }
    }
}
