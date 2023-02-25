using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class PaginationValueRepositoryCache<TValue> : BaseRepositoryCache, IPaginationValueRepositoryCache<TValue>
    {
        public PaginationValueRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }
        public async Task<bool> TryExistsAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryExistsAsync(Project, Container, cancellationToken);
            return result;
        }

        public async Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryRemoveAsync(Project, Container, cancellationToken);
            return result;
        }
        public async Task<bool> TrySetAsync(IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySetAsync(Project, Container, Expiry, values, cancellationToken);
            return result;
        }

        public async Task<IPaginationCache<TValue>> TryGetAsync(int numberPage, int sizePage, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryGetAsync<TValue>(Project, Container, numberPage, sizePage, cancellationToken);
            return result;
        }
    }
}
