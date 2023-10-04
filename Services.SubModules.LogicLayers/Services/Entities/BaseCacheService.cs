using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Abstract base class for caching service implementations.
    /// </summary>
    public abstract class BaseCacheService : ICacheService, IDisposable
    {
        /// <summary>
        /// Dispose of any resources held by the cache service.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Generates a cache key hash based on project and container information.
        /// </summary>
        protected virtual string GetKeyHash(string project, string container)
        {
            var result = $"{project}:{container}";
            return result;
        }

        /// <summary>
        /// Generates a cache key hash based on project, container, and a key value.
        /// </summary>
        protected virtual string GetKeyHash<TKey>(string project, string container, TKey key)
        {
            var result = $"{project}:{container}:{key}";
            return result;
        }

        /// <summary>
        /// Asynchronously checks if a cached entry with the specified key exists.
        /// </summary>
        public abstract Task<bool> TryExistsAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously removes a cached entry with the specified key.
        /// </summary>
        public abstract Task<bool> TryRemoveAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously attempts to retrieve a cached entry by key.
        /// </summary>
        public abstract Task<(bool isSuccessful, TValue value)> TryGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously attempts to set a cached entry with the specified key and value.
        /// </summary>
        public abstract Task<bool> TrySetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to set a hash value in the cache asynchronously.
        /// </summary>
        public abstract Task<bool> TryHashSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to set multiple hash values in the cache asynchronously.
        /// </summary>
        public abstract Task<bool> TryHashSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, IDictionary<TKey, TValue> values, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to get a hash value from the cache asynchronously.
        /// </summary>
        public abstract Task<(bool isSuccessful, TValue value)> TryHashGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to get all hash values from the cache asynchronously.
        /// </summary>
        public abstract Task<(bool isSuccessful, IEnumerable<TValue> values)> TryHashGetAllAsync<TKey, TValue>(string project, string container, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to set paginated values in the cache asynchronously.
        /// </summary>
        public abstract Task<bool> TryPaginationSetAsync<TValue>(string project, string container, TimeSpan? expiry, IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to get paginated values from the cache asynchronously.
        /// </summary>
        public abstract Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryPaginationGetAsync<TValue>(string project, string container, IPaginationRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to get all paginated values from the cache asynchronously.
        /// </summary>
        public abstract Task<(bool isSuccessful, IEnumerable<TValue> values)> TryPaginationGetAllAsync<TValue>(string project, string container, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to set paginated values for a specific key in the cache asynchronously.
        /// </summary>
        public abstract Task<bool> TryPaginationSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to get paginated values for a specific key from the cache asynchronously.
        /// </summary>
        public abstract Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryPaginationGetAsync<TKey, TValue>(string project, string container, TKey key, IPaginationRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Tries to get all paginated values for a specific key from the cache asynchronously.
        /// </summary>
        public abstract Task<(bool isSuccessful, IEnumerable<TValue> values)> TryPaginationGetAllAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves keys from Redis cache based on a pattern.
        /// </summary>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key pattern to search for in Redis.</param>
        /// <returns>A tuple containing a boolean indicating success and a list of matching keys.</returns>
        public abstract Task<(bool isSuccessful, IEnumerable<string> values)> TryGetKeysAsync<TKey>(string project, string container, TKey key);

        /// <summary>
        /// Asynchronously retrieves values associated with keys from Redis cache.
        /// </summary>
        /// <typeparam name="TKey">The type of keys to retrieve.</typeparam>
        /// <typeparam name="TValue">The type of values to retrieve.</typeparam>
        /// <param name="keys">The collection of keys to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A tuple containing a boolean indicating success and a list of retrieved values.</returns>
        public abstract Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAsync<TKey, TValue>(IEnumerable<TKey> keys, CancellationToken cancellationToken = default);
    }
}
