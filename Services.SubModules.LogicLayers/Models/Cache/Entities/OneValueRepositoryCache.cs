using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    /// <summary>
    /// Represents a cache that stores a single value with a key.
    /// </summary>
    /// <typeparam name="TValue">The type of the cached value.</typeparam>
    public class OneValueRepositoryCache<TValue> : OneRepositoryCache, IOneValueRepositoryCache<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneValueRepositoryCache{TValue}"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service to be used.</param>
        /// <param name="project">The project associated with the cache.</param>
        /// <param name="container">The container associated with the cache.</param>
        /// <param name="expiry">The expiration duration for cached items.</param>
        public OneValueRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        /// <summary>
        /// Tries to set a value in the cache.
        /// </summary>
        /// <param name="value">The value to be cached.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the value was successfully cached.</returns>
        public async Task<bool> TrySetAsync(TValue value, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySetAsync(Project, Container, Expiry, string.Empty, value, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to retrieve a value from the cache.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple containing a boolean indicating whether the retrieval was successful, and the retrieved value.</returns>
        public async Task<(bool isSuccessful, TValue value)> TryGetAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryGetAsync<string, TValue>(Project, Container, string.Empty, cancellationToken);
            return result;
        }
    }
}
