using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    /// <summary>
    /// Represents an abstract base class for a cache that stores a single value associated with a key.
    /// </summary>
    public abstract class OneRepositoryCache : BaseRepositoryCache, IOneRepositoryCache
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneRepositoryCache"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service to be used.</param>
        /// <param name="project">The project associated with the cache.</param>
        /// <param name="container">The container associated with the cache.</param>
        /// <param name="expiry">The expiration duration for cached items.</param>
        protected OneRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        /// <summary>
        /// Tries to determine if a cached value exists.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the cached value exists.</returns>
        public virtual async Task<bool> TryExistsAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryExistsAsync(Project, Container, string.Empty, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to remove the cached value.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the cached value was successfully removed.</returns>
        public virtual async Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryRemoveAsync(Project, Container, string.Empty, cancellationToken);
            return result;
        }
    }
}
