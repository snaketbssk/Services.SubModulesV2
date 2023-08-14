using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    /// <summary>
    /// Represents a base class for a cache that stores multiple items associated with a key.
    /// </summary>
    /// <typeparam name="TKey">The type of the cache key.</typeparam>
    public abstract class ManyRepositoryCache<TKey> : BaseRepositoryCache, IManyRepositoryCache<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyRepositoryCache{TKey}"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service to be used.</param>
        /// <param name="project">The project associated with the cache.</param>
        /// <param name="container">The container associated with the cache.</param>
        /// <param name="expiry">The expiration duration for cached items.</param>
        protected ManyRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        /// <summary>
        /// Tries to check if an item associated with the specified key exists in the cache.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the item exists in the cache.</returns>
        public async Task<bool> TryExistsAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryExistsAsync(Project, Container, key, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to remove an item associated with the specified key from the cache.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the removal operation was successful.</returns>
        public async Task<bool> TryRemoveAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryRemoveAsync(Project, Container, key, cancellationToken);
            return result;
        }
    }
}
