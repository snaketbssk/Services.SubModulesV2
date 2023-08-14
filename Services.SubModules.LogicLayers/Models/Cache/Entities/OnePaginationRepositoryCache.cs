using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    /// <summary>
    /// Represents a cache for storing paginated data associated with a single key.
    /// </summary>
    /// <typeparam name="TValue">The type of the cached values.</typeparam>
    public class OnePaginationRepositoryCache<TValue> : OneRepositoryCache, IOnePaginationRepositoryCache<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnePaginationRepositoryCache{TValue}"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service to be used.</param>
        /// <param name="project">The project associated with the cache.</param>
        /// <param name="container">The container associated with the cache.</param>
        /// <param name="expiry">The expiration duration for cached items.</param>
        public OnePaginationRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        /// <summary>
        /// Tries to set paginated values in the cache.
        /// </summary>
        /// <param name="values">The paginated values to be cached.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the values were successfully cached.</returns>
        public async Task<bool> TrySetAsync(IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationSetAsync(Project, Container, Expiry, values, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to retrieve paginated values from the cache based on a pagination request.
        /// </summary>
        /// <param name="request">The pagination request parameters.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple containing a boolean indicating success and the retrieved pagination response.</returns>
        public async Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryGetAsync(IPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAsync<TValue>(Project, Container, request, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to retrieve all paginated values from the cache.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple containing a boolean indicating success and a collection of retrieved values.</returns>
        public async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAllAsync<TValue>(Project, Container, cancellationToken);
            return result;
        }
    }
}
