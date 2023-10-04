using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICacheService
    {
        Task<bool> TryExistsAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        Task<(bool isSuccessful, TValue value)> TryGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default);

        Task<bool> TryHashSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default);
        Task<bool> TryHashSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, IDictionary<TKey, TValue> values, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, TValue value)> TryHashGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryHashGetAllAsync<TKey, TValue>(string project, string container, CancellationToken cancellationToken = default);

        Task<bool> TryPaginationSetAsync<TValue>(string project, string container, TimeSpan? expiry, IEnumerable<TValue> values, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryPaginationGetAsync<TValue>(string project, string container, IPaginationRequest request, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryPaginationGetAllAsync<TValue>(string project, string container, CancellationToken cancellationToken = default);

        Task<bool> TryPaginationSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryPaginationGetAsync<TKey, TValue>(string project, string container, TKey key, IPaginationRequest request, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryPaginationGetAllAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves keys from Redis cache based on a pattern.
        /// </summary>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key pattern to search for in Redis.</param>
        /// <returns>A tuple containing a boolean indicating success and a list of matching keys.</returns>
        Task<(bool isSuccessful, IEnumerable<string> values)> TryGetKeysAsync<TKey>(string project, string container, TKey key);

        /// <summary>
        /// Asynchronously retrieves values associated with keys from Redis cache.
        /// </summary>
        /// <typeparam name="TKey">The type of keys to retrieve.</typeparam>
        /// <typeparam name="TValue">The type of values to retrieve.</typeparam>
        /// <param name="keys">The collection of keys to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A tuple containing a boolean indicating success and a list of retrieved values.</returns>
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAsync<TKey, TValue>(IEnumerable<TKey> keys, CancellationToken cancellationToken = default);
    }
}
