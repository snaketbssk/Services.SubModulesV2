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
        /// Tries to set a cached value associated with a specific key in the cache.
        /// </summary>
        /// <param name="key">The key associated with the cached value.</param>
        /// <param name="value">The value to be cached.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the setting of the cached value was successful.</returns>
        Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default);
    }
}
