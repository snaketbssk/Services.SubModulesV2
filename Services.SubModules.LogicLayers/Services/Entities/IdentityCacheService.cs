using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;
using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class IdentityCacheService : IIdentityCacheService
    {
        public IManyRepositoryCache<string, UserRedis> User { get; private set; }

        public IdentityCacheService(ICacheService cacheService)
        {
            User = new ManyRepositoryCache<string, UserRedis>(cacheService,
                                                                nameof(IdentityCacheService),
                                                                nameof(User),
                                                                TimeSpan.FromMinutes(10));
        }
    }
}
