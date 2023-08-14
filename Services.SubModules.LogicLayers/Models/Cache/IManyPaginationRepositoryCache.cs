using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    /// <summary>
    /// Represents a cache that stores and retrieves paginated collections of values with a specified key.
    /// </summary>
    /// <typeparam name="TKey">The type of the key used for caching.</typeparam>
    /// <typeparam name="TValue">The type of the cached values.</typeparam>
    public interface IManyPaginationRepositoryCache<TKey, TValue> : IManyRepositoryCache<TKey>
    {
        /// <summary>
        /// Tries to set a paginated collection of values in the cache.
        /// </summary>
        /// <param name="key">The key associated with the cached values.</param>
        /// <param name="values">The values to be cached.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the values were successfully cached.</returns>
        Task<bool> TrySetAsync(TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to retrieve a paginated collection of values from the cache.
        /// </summary>
        /// <param name="key">The key associated with the cached values.</param>
        /// <param name="request">The pagination request specifying the desired subset of values.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple containing a boolean indicating whether the retrieval was successful, and the retrieved paginated response.</returns>
        Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryGetAsync(TKey key, IPaginationRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to retrieve all paginated values associated with a key from the cache.
        /// </summary>
        /// <param name="key">The key associated with the cached values.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple containing a boolean indicating whether the retrieval was successful, and the retrieved paginated values.</returns>
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(TKey key, CancellationToken cancellationToken = default);
    }
}
