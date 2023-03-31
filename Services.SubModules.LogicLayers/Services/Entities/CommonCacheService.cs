using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class CommonCacheService : ICommonCacheService
    {
        public IOneRepositoryCache<string> Value { get; private set; }
        public IManyRepositoryCache<string, string> Values { get; private set; }
        public IHashRepositoryCache<string, string> Hash { get; private set; }
        public IOnePaginationRepositoryCache<string> Pagination { get; private set; }

        public CommonCacheService(ICacheService cacheService)
        {
            Value = new OneRepositoryCache<string>(cacheService,
                                                     nameof(CommonCacheService),
                                                     nameof(Value),
                                                     TimeSpan.FromMinutes(1));
            Values = new ManyRepositoryCache<string, string>(cacheService,
                                                      nameof(CommonCacheService),
                                                      nameof(Values),
                                                      TimeSpan.FromMinutes(1));
            Hash = new HashRepositoryCache<string, string>(cacheService,
                                                      nameof(CommonCacheService),
                                                      nameof(Hash),
                                                      TimeSpan.FromMinutes(1));
            Pagination = new OnePaginationRepositoryCache<string>(cacheService,
                                                      nameof(CommonCacheService),
                                                      nameof(Pagination),
                                                      TimeSpan.FromMinutes(1));
        }
    }
}
