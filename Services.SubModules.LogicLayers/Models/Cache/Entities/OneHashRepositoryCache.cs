using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    /// <summary>
    /// Represents a cache for storing multiple values associated with hash keys.
    /// </summary>
    /// <typeparam name="TKey">The type of the hash key.</typeparam>
    /// <typeparam name="TValue">The type of the cached values.</typeparam>
    public class OneHashRepositoryCache<TKey, TValue> : OneRepositoryCache, IOneHashRepositoryCache<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneHashRepositoryCache{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service to be used.</param>
        /// <param name="project">The project associated with the cache.</param>
        /// <param name="container">The container associated with the cache.</param>
        /// <param name="expiry">The expiration duration for cached items.</param>
        public OneHashRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        /// <summary>
        /// Tries to set a value associated with the specified hash key in the cache.
        /// </summary>
        /// <param name="key">The hash key.</param>
        /// <param name="value">The value to be cached.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the value was successfully cached.</returns>
        public async Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryHashSetAsync(Project, Container, Expiry, key, value, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to set multiple values associated with hash keys in the cache.
        /// </summary>
        /// <param name="values">A dictionary containing hash keys and corresponding values.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the values were successfully cached.</returns>
        public async Task<bool> TrySetAsync(IDictionary<TKey, TValue> values, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryHashSetAsync(Project, Container, Expiry, values, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to retrieve a value associated with the specified hash key from the cache.
        /// </summary>
        /// <param name="key">The hash key.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple containing a boolean indicating success and the retrieved value.</returns>
        public async Task<(bool isSuccessful, TValue value)> TryGetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryHashGetAsync<TKey, TValue>(Project, Container, key, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to retrieve all values associated with hash keys from the cache.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple containing a boolean indicating success and a collection of retrieved values.</returns>
        public async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryHashGetAllAsync<TKey, TValue>(Project, Container, cancellationToken);
            return result;
        }
    }
}
