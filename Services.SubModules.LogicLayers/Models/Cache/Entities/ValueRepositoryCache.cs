using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class ValueRepositoryCache<TValue> : BaseRepositoryCache, IValueRepositoryCache<TValue>
    {
        public ValueRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
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

        public async Task<bool> TrySetAsync(TValue value, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySetAsync(Project, Container, Expiry, value, cancellationToken);
            return result;
        }

        public async Task<IValuesCache<TValue>> TryGetAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryGetAsync<TValue>(Project, Container, cancellationToken);
            return result;
        }
    }
}
