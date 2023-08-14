namespace Services.SubModules.LogicLayers.Models.Cache
{
    /// <summary>
    /// Represents a cache that stores and retrieves multiple values associated with a key.
    /// </summary>
    /// <typeparam name="TKey">The type of the key used for caching.</typeparam>
    public interface IManyRepositoryCache<TKey> : IRepositoryCache
    {
        /// <summary>
        /// Tries to check if values associated with a specific key exist in the cache.
        /// </summary>
        /// <param name="key">The key associated with the cached values.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether values associated with the key exist in the cache.</returns>
        Task<bool> TryExistsAsync(TKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to remove values associated with a specific key from the cache.
        /// </summary>
        /// <param name="key">The key associated with the cached values.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the removal of values associated with the key was successful.</returns>
        Task<bool> TryRemoveAsync(TKey key, CancellationToken cancellationToken = default);
    }
}
