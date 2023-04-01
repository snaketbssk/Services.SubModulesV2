using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;
using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class IdentityCacheService : IIdentityCacheService
    {
        public IManyValueRepositoryCache<string, UserRedis> User { get; private set; }

        public IdentityCacheService(ICacheService cacheService)
        {
            User = new ManyValueRepositoryCache<string, UserRedis>(cacheService,
                                                                nameof(IdentityCacheService),
                                                                nameof(User),
                                                                TimeSpan.FromMinutes(10));
        }
    }
}
