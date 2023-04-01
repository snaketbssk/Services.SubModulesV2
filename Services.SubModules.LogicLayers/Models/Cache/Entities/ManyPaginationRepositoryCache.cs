using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class ManyPaginationRepositoryCache<TKey, TValue> : ManyRepositoryCache<TKey>, IManyPaginationRepositoryCache<TKey, TValue>
    {
        public ManyPaginationRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        public async Task<bool> TrySetAsync(TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationSetAsync(Project, Container, Expiry, key, values, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, IEnumerable<TValue> values, int totalCount)> TryGetAsync(TKey key, int numberPage, int sizePage, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAsync<TKey, TValue>(Project, Container, key, numberPage, sizePage, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAllAsync<TKey, TValue>(Project, Container, key, cancellationToken);
            return result;
        }
    }
}
