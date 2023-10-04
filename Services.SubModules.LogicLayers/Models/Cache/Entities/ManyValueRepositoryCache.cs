using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    /// <summary>
    /// Represents a cache for storing individual values associated with a key.
    /// </summary>
    /// <typeparam name="TKey">The type of the cache key.</typeparam>
    /// <typeparam name="TValue">The type of the cached values.</typeparam>
    public class ManyValueRepositoryCache<TKey, TValue> : ManyRepositoryCache<TKey>, IManyValueRepositoryCache<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyValueRepositoryCache{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service to be used.</param>
        /// <param name="project">The project associated with the cache.</param>
        /// <param name="container">The container associated with the cache.</param>
        /// <param name="expiry">The expiration duration for cached items.</param>
        public ManyValueRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        /// <summary>
        /// Tries to set a value associated with the specified key in the cache.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The value to be cached.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the value was successfully cached.</returns>
        public async Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TrySetAsync(Project, Container, Expiry, key, value, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to retrieve a value associated with the specified key from the cache.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple containing a boolean indicating success and the retrieved value.</returns>
        public async Task<(bool isSuccessful, TValue value)> TryGetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryGetAsync<TKey, TValue>(Project, Container, key, cancellationToken);
            return result;
        }

        /// <summary>
        /// Asynchronously retrieves values associated with keys from Redis cache.
        /// </summary>
        /// <typeparam name="TKey">The type of keys to retrieve.</typeparam>
        /// <typeparam name="TValue">The type of values to retrieve.</typeparam>
        /// <param name="keys">The collection of keys to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A tuple containing a boolean indicating success and a list of retrieved values.</returns>
        public async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAsync(IEnumerable<TKey> keys, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryGetAsync<TKey, TValue>(keys, cancellationToken);
            return result;
        }

        /// <summary>
        /// Asynchronously retrieves keys from Redis cache based on a pattern.
        /// </summary>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key pattern to search for in Redis.</param>
        /// <returns>A tuple containing a boolean indicating success and a list of matching keys.</returns>
        public async Task<(bool isSuccessful, IEnumerable<string> values)> TryGetKeysAsync(TKey key)
        {
            var result = await CacheService.TryGetKeysAsync(Project, Container, key);
            return result;
        }
    }
}
