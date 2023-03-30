using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class ValueRepositoryCache<TValue> : BaseRepositoryCache, IValueRepositoryCache<TValue>
    {
        public ValueRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        public async Task<bool> TrySetAsync(TValue value, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySingleSetAsync(Project, Container, Expiry, string.Empty, value, cancellationToken);
            return result;
        }

        public async Task<(bool isSuccessful, TValue value)> TryGetAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySingleGetAsync<string, TValue>(Project, Container, string.Empty, cancellationToken);
            return result;
        }
    }
}
