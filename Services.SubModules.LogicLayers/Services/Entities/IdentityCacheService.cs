using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;
using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class IdentityCacheService : IIdentityCacheService
    {
        public IManyValueRepositoryCache<string, UserRedis> Users { get; private set; }
        public IManyValueRepositoryCache<string, string> Sessions { get; private set; }

        public IdentityCacheService(ICacheService cacheService)
        {
            Users = new ManyValueRepositoryCache<string, UserRedis>(cacheService,
                                                                   nameof(IdentityCacheService),
                                                                   nameof(Users),
                                                                   TimeSpan.FromMinutes(10));
            Sessions = new ManyValueRepositoryCache<string, string>(cacheService,
                                                                    nameof(IdentityCacheService),
                                                                    nameof(Sessions),
                                                                    TimeSpan.FromDays(1));
        }
    }
}
