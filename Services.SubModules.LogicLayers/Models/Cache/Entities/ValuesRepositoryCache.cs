using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class ValuesRepositoryCache<TKey, TValue> : BaseRepositoryCache, IValuesRepositoryCache<TKey, TValue>
    {
        public ValuesRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        public async Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySingleSetAsync(Project, Container, Expiry, key, value, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, TValue value)> TryGetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySingleGetAsync<TKey, TValue>(Project, Container, key, cancellationToken);
            return result;
        }
    }
}
