using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class HashRepositoryCache<TKey, TValue> : BaseRepositoryCache, IHashRepositoryCache<TKey, TValue>
    {
        public HashRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        public async Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryHashSetAsync(Project, Container, Expiry, key, value, cancellationToken);
            return result;
        }

        public async Task<bool> TrySetAsync(IDictionary<TKey, TValue> values, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryHashSetAsync(Project, Container, Expiry, values, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, TValue value)> TryGetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryHashGetAsync<TKey, TValue>(Project, Container, key, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryHashGetAllAsync<TKey, TValue>(Project, Container, cancellationToken);
            return result;
        }
    }
}
