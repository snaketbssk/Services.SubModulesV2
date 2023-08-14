using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    /// <summary>
    /// Represents a cache for storing paginated data associated with a specific key.
    /// </summary>
    /// <typeparam name="TKey">The type of the cache key.</typeparam>
    /// <typeparam name="TValue">The type of the cached values.</typeparam>
    public class ManyPaginationRepositoryCache<TKey, TValue> : ManyRepositoryCache<TKey>, IManyPaginationRepositoryCache<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManyPaginationRepositoryCache{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service to be used.</param>
        /// <param name="project">The project associated with the cache.</param>
        /// <param name="container">The container associated with the cache.</param>
        /// <param name="expiry">The expiration duration for cached items.</param>
        public ManyPaginationRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
            : base(cacheService, project, container, expiry)
        {
        }

        /// <summary>
        /// Tries to set paginated data in the cache associated with the specified key.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="values">The paginated values to be cached.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        public async Task<bool> TrySetAsync(TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationSetAsync(Project, Container, Expiry, key, values, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to get paginated data from the cache associated with the specified key and pagination request.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="request">The pagination request.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple indicating whether the operation was successful and the retrieved paginated data.</returns>
        public async Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryGetAsync(TKey key, IPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAsync<TKey, TValue>(Project, Container, key, request, cancellationToken);
            return result;
        }

        /// <summary>
        /// Tries to get all paginated data associated with the specified key from the cache.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="cancellationToken">A cancellation token to observe cancellation requests.</param>
        /// <returns>A tuple indicating whether the operation was successful and the retrieved paginated data.</returns>
        public async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryPaginationGetAllAsync<TKey, TValue>(Project, Container, key, cancellationToken);
            return result;
        }
    }
}
