using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public abstract class ManyRepositoryCache<TKey> : BaseRepositoryCache, IManyRepositoryCache<TKey>
    {
        protected ManyRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
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
    }
}
