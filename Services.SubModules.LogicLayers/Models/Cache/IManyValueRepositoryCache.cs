namespace Services.SubModules.LogicLayers.Models.Cache
{
    /// <summary>
    /// Represents a cache that stores and retrieves multiple values associated with a key.
    /// </summary>
    /// <typeparam name="TKey">The type of the key used for caching.</typeparam>
    /// <typeparam name="TValue">The type of the values to be cached.</typeparam>
    public interface IManyValueRepositoryCache<TKey, TValue> : IManyRepositoryCache<TKey>
    {
        /// <summary>
        /// Tries to retrieve a cached value associated with a specific key from the cache.
        /// </summary>
        /// <param name="key">The key associated with the cached value.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>
        /// A tuple where the first element indicates whether the retrieval was successful,
        /// and the second element contains the retrieved cached value (if successful).
        /// </returns>
        Task<(bool isSuccessful, TValue value)> TryGetAsync(TKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves values associated with keys from Redis cache.
        /// </summary>
        /// <typeparam name="TKey">The type of keys to retrieve.</typeparam>
        /// <typeparam name="TValue">The type of values to retrieve.</typeparam>
        /// <param name="keys">The collection of keys to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A tuple containing a boolean indicating success and a list of retrieved values.</returns>
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAsync(IEnumerable<TKey> keys, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves keys from Redis cache based on a pattern.
        /// </summary>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key pattern to search for in Redis.</param>
        /// <returns>A tuple containing a boolean indicating success and a list of matching keys.</returns>
        Task<(bool isSuccessful, IEnumerable<string> values)> TryGetKeysAsync(TKey key);

        /// <summary>
        /// Tries to set a cached value associated with a specific key in the cache.
        /// </summary>
        /// <param name="key">The key associated with the cached value.</param>
        /// <param name="value">The value to be cached.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the setting of the cached value was successful.</returns>
        Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default);
    }
}
