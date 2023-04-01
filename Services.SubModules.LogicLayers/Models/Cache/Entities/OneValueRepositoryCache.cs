using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class OneValueRepositoryCache<TValue> : OneRepositoryCache, IOneValueRepositoryCache<TValue>
    {
        public OneValueRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        public async Task<bool> TrySetAsync(TValue value, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySetAsync(Project, Container, Expiry, string.Empty, value, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, TValue value)> TryGetAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryGetAsync<string, TValue>(Project, Container, string.Empty, cancellationToken);
            return result;
        }
    }
}
