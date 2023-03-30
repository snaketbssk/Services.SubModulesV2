using Services.SubModules.LogicLayers.Models.Cache.Entities;
using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class CommonCacheService : ICommonCacheService
    {
        public IValueRepositoryCache<string> Value { get; private set; }
        public IValuesRepositoryCache<string, string> Values { get; private set; }
        public IHashRepositoryCache<string, string> Hash { get; private set; }
        public IPaginationRepositoryCache<string> Pagination { get; private set; }

        public CommonCacheService(ICacheService cacheService)
        {
            Value = new ValueRepositoryCache<string>(cacheService,
                                                     nameof(CommonCacheService),
                                                     nameof(Value),
                                                     TimeSpan.FromMinutes(1));
            Values = new ValuesRepositoryCache<string, string>(cacheService,
                                                      nameof(CommonCacheService),
                                                      nameof(Values),
                                                      TimeSpan.FromMinutes(1));
            Hash = new HashRepositoryCache<string, string>(cacheService,
                                                      nameof(CommonCacheService),
                                                      nameof(Hash),
                                                      TimeSpan.FromMinutes(1));
            Pagination = new PaginationRepositoryCache<string>(cacheService,
                                                      nameof(CommonCacheService),
                                                      nameof(Pagination),
                                                      TimeSpan.FromMinutes(1));
        }
    }
}
