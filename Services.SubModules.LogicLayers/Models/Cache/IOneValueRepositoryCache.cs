namespace Services.SubModules.LogicLayers.Models.Cache
{
    /// <summary>
    /// Represents a cache that stores and retrieves a single value using a specific configuration.
    /// </summary>
    /// <typeparam name="TValue">The type of the value to be stored in the cache.</typeparam>
    public interface IOneValueRepositoryCache<TValue> : IOneRepositoryCache
    {
        /// <summary>
        /// Tries to retrieve a value from the cache.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple indicating whether the retrieval was successful and the retrieved value.</returns>
        Task<(bool isSuccessful, TValue value)> TryGetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to store a value in the cache.
        /// </summary>
        /// <param name="value">The value to be stored in the cache.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the storing of the value was successful.</returns>
        Task<bool> TrySetAsync(TValue value, CancellationToken cancellationToken = default);
    }
}
