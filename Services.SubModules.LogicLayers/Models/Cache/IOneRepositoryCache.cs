namespace Services.SubModules.LogicLayers.Models.Cache
{
    /// <summary>
    /// Represents a cache that stores and retrieves single values using a specific configuration.
    /// </summary>
    public interface IOneRepositoryCache : IRepositoryCache
    {
        /// <summary>
        /// Tries to check if a value exists in the cache.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the value exists in the cache.</returns>
        Task<bool> TryExistsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to remove a value from the cache.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the removal of the value was successful.</returns>
        Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default);
    }
}
