using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class PaginationValuesRepositoryCache<TKey, TValue> : BaseRepositoryCache, IPaginationValuesRepositoryCache<TKey, TValue>
    {
        public PaginationValuesRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        public async Task<bool> TryExistsAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryExistsAsync(Project, Container, key, cancellationToken);
            return result;
        }

        public async Task<bool> TryRemoveAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryRemoveAsync(Project, Container, key, cancellationToken);
            return result;
        }

        public async Task<bool> TrySetAsync(TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySetAsync(Project, Container, Expiry, key, values, cancellationToken);
            return result;
        }

        public async Task<IPaginationCache<TValue>> TryGetAsync(TKey key, int numberPage, int sizePage, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryGetAsync<TKey, TValue>(Project, Container, key, numberPage, sizePage, cancellationToken);
            return result;
        }
    }
}
