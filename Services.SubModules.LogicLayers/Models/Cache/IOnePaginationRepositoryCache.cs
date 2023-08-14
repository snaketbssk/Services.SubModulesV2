using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    /// <summary>
    /// Represents a cache that stores and retrieves paginated values using a specific configuration.
    /// </summary>
    /// <typeparam name="TValue">The type of the values to be cached.</typeparam>
    public interface IOnePaginationRepositoryCache<TValue> : IOneRepositoryCache
    {
        /// <summary>
        /// Tries to set a collection of paginated values in the cache.
        /// </summary>
        /// <param name="values">The collection of values to be cached.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the setting of the cached values was successful.</returns>
        Task<bool> TrySetAsync(IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to retrieve paginated values from the cache based on the specified pagination request.
        /// </summary>
        /// <param name="request">The pagination request specifying the desired page and page size.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>
        /// A tuple where the first element indicates whether the retrieval was successful,
        /// and the second element contains the retrieved pagination response (if successful).
        /// </returns>
        Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryGetAsync(IPaginationRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to retrieve all paginated values from the cache.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>
        /// A tuple where the first element indicates whether the retrieval was successful,
        /// and the second element contains the retrieved collection of paginated values (if successful).
        /// </returns>
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(CancellationToken cancellationToken = default);
    }
}
