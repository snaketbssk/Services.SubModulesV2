using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;
using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class IdentityCacheService : IIdentityCacheService
    {
        public IValuesRepositoryCache<string, UserRedis> User { get; private set; }

        public IdentityCacheService(ICacheService cacheService)
        {
            User = new ValuesRepositoryCache<string, UserRedis>(cacheService,
                                                                CacheConstant.IDENTITY_PROJECT,
                                                                CacheConstant.USER_CONTAINER,
                                                                TimeSpan.FromMinutes(10));
        }
    }
}
