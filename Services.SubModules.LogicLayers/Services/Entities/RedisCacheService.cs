using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using StackExchange.Redis;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for interacting with Redis cache.
    /// </summary>
    public class RedisCacheService : BaseCacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private bool isDispose { get; set; }

        /// <summary>
        /// Initializes a new instance of the RedisCacheService class.
        /// </summary>
        /// <param name="connectionMultiplexer">The Redis connection multiplexer.</param>
        protected RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        /// <summary>
        /// Initializes and returns an instance of the RedisCacheService.
        /// </summary>
        /// <param name="enableCache">Indicates whether caching is enabled.</param>
        /// <returns>An instance of RedisCacheService if caching is enabled; otherwise, null.</returns>
        public static ICacheService Initialization(bool enableCache)
        {
            if (!enableCache)
                return new RedisCacheService(default);

            try
            {
                var root = RedisEnvironmentConfiguration<RedisEnvironmentRoot>.Instance.GetRoot();

                ArgumentNullException.ThrowIfNull(root, nameof(root));
                ArgumentNullException.ThrowIfNull(root.CONNECTION, nameof(root.CONNECTION));

                var connectionMultiplexer = ConnectionMultiplexer.Connect(root.CONNECTION);
                var result = new RedisCacheService(connectionMultiplexer);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Disposes of the RedisCacheService instance and releases resources.
        /// </summary>
        public override async void Dispose()
        {
            if (!isDispose && _connectionMultiplexer is not null)
            {
                isDispose = true;
                await _connectionMultiplexer.CloseAsync();
            }
        }

        /// <summary>
        /// Checks if a specified key exists in the Redis database.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key whose existence needs to be checked.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>Returns true if the key exists, otherwise false.</returns>
        public override async Task<bool> TryExistsAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container, key);
                var result = await database.KeyExistsAsync(keyHash);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to remove a key from the Redis database.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key to be removed.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>Returns true if the key was removed successfully, otherwise false.</returns>
        public override async Task<bool> TryRemoveAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container, key);
                var result = await database.KeyDeleteAsync(keyHash);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to retrieve a value from the Redis database using the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value to retrieve.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key whose value needs to be retrieved.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A tuple indicating if the operation was successful and the retrieved value.</returns>
        public override async Task<(bool isSuccessful, TValue value)> TryGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container, key);
                var redisValue = await database.StringGetAsync(keyHash);

                if (!redisValue.HasValue || redisValue.IsNullOrEmpty)
                    return default;

                var value = JsonSerializer.Deserialize<TValue>(redisValue.ToString());

                if (value is null)
                    return default;

                return (true, value);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Attempts to set a value in the Redis database using the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value to set.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="expiry">Optional expiration time for the key.</param>
        /// <param name="key">The key at which to set the value.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>Returns true if the value was set successfully, otherwise false.</returns>
        public override async Task<bool> TrySetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);
                ArgumentNullException.ThrowIfNull(value);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container, key);
                var valueHash = JsonSerializer.Serialize(value);
                var result = await database.StringSetAsync(keyHash, valueHash, expiry);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to retrieve all values from a hash in the Redis database.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the values to retrieve.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A tuple indicating if the operation was successful and the retrieved values.</returns>
        public override async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryHashGetAllAsync<TKey, TValue>(string project, string container, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);

                var redisValues = await database.HashGetAllAsync(keyHash);
                if (redisValues.Length == 0)
                    return default;

                var values = redisValues.Select(x => JsonSerializer.Deserialize<TValue>(x.Value.ToString())).ToList();

                return (true, values);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Attempts to retrieve a value from a hash in the Redis database using the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value to retrieve.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key within the hash to retrieve.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A tuple indicating if the operation was successful and the retrieved value.</returns>
        public override async Task<(bool isSuccessful, TValue value)> TryHashGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);

                var redisValue = await database.HashGetAsync(keyHash, key.ToString());
                if (!redisValue.HasValue || redisValue.IsNullOrEmpty)
                    return default;

                var value = JsonSerializer.Deserialize<TValue>(redisValue.ToString());
                ArgumentNullException.ThrowIfNull(value);

                return (true, value);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Attempts to set a value in a hash in the Redis database using the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value to set.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="expiry">Optional expiration time for the key.</param>
        /// <param name="key">The key within the hash to set.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>Returns true if the value was set successfully, otherwise false.</returns>
        public override async Task<bool> TryHashSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);
                ArgumentNullException.ThrowIfNull(value);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);

                await database.HashSetAsync(keyHash, key.ToString(), JsonSerializer.Serialize(value));

                if (expiry.HasValue)
                    await database.KeyExpireAsync(keyHash, expiry);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to set multiple key-value pairs in a hash in the Redis database.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <typeparam name="TValue">The type of the values to set.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="expiry">Optional expiration time for the key.</param>
        /// <param name="values">The key-value pairs to set in the hash.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>Returns true if the values were set successfully, otherwise false.</returns>
        public override async Task<bool> TryHashSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, IDictionary<TKey, TValue> values, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);

                var hashValues = values.Select(x => new HashEntry(x.Key.ToString(), JsonSerializer.Serialize(x.Value))).ToArray();
                await database.HashSetAsync(keyHash, hashValues);

                if (expiry.HasValue)
                    await database.KeyExpireAsync(keyHash, expiry);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to set a list of values in the Redis database for pagination purposes.
        /// </summary>
        /// <typeparam name="TValue">The type of the values to set.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="expiry">Optional expiration time for the key.</param>
        /// <param name="values">The values to set for pagination.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>Returns true if the values were set successfully, otherwise false.</returns>
        public override async Task<bool> TryPaginationSetAsync<TValue>(string project, string container, TimeSpan? expiry, IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(values);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);

                var hashValues = values.Select(x => new RedisValue(JsonSerializer.Serialize(x))).ToArray();

                await database.KeyDeleteAsync(keyHash);
                await database.ListRightPushAsync(keyHash, hashValues);

                if (expiry.HasValue)
                    await database.KeyExpireAsync(keyHash, expiry);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to retrieve a paginated set of values from a Redis list.
        /// </summary>
        /// <typeparam name="TValue">The type of the values to retrieve.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="request">The pagination request details.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A tuple indicating if the operation was successful and the paginated values.</returns>
        public override async Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryPaginationGetAsync<TValue>(string project, string container, IPaginationRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);

                int startIndex = (request.NumberPage - 1) * request.SizePage;
                int endIndex = request.NumberPage * request.SizePage - 1;

                var redisValues = await database.ListRangeAsync(keyHash, startIndex, endIndex);
                var values = redisValues.Where(x => x.HasValue)
                                        .Select(x => JsonSerializer.Deserialize<TValue>(x.ToString()))
                                        .ToList();

                var totalCount = await database.ListLengthAsync(keyHash);

                var pagination = new PaginationResponse<TValue>()
                {
                    TotalCount = (int)totalCount,
                    Values = values
                };

                return (true, pagination);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Attempts to retrieve a paginated set of values from a Redis list.
        /// </summary>
        /// <typeparam name="TValue">The type of the values to retrieve.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="request">The pagination request details.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A tuple indicating if the operation was successful and the paginated values.</returns>
        public override async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryPaginationGetAllAsync<TValue>(string project, string container, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);

                var redisValues = await database.ListRangeAsync(keyHash);
                var values = redisValues.Where(x => x.HasValue)
                                        .Select(x => JsonSerializer.Deserialize<TValue>(x.ToString()));
                return (true, values);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Attempts to set a paginated list of values in the Redis database for a specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the values to set.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="expiry">Optional expiration time for the key.</param>
        /// <param name="key">The key within the Redis database to set the paginated values.</param>
        /// <param name="values">The values to set for pagination.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>Returns true if the values were set successfully, otherwise false.</returns>
        public override async Task<bool> TryPaginationSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);
                ArgumentNullException.ThrowIfNull(values);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container, key);

                var hashValues = values.Select(x => new RedisValue(JsonSerializer.Serialize(x))).ToArray();

                await database.KeyDeleteAsync(keyHash);
                await database.ListRightPushAsync(keyHash, hashValues);

                if (expiry.HasValue)
                    await database.KeyExpireAsync(keyHash, expiry);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to retrieve a paginated set of values from a Redis list for a specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the values to retrieve.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key within the Redis database to retrieve the paginated values.</param>
        /// <param name="request">The pagination request details.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A tuple indicating if the operation was successful and the paginated values.</returns>
        public override async Task<(bool isSuccessful, IPaginationResponse<TValue> pagination)> TryPaginationGetAsync<TKey, TValue>(string project, string container, TKey key, IPaginationRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container, key);

                int startIndex = (request.NumberPage - 1) * request.SizePage;
                int endIndex = request.NumberPage * request.SizePage - 1;

                var redisValues = await database.ListRangeAsync(keyHash, startIndex, endIndex);
                var values = redisValues.Where(x => x.HasValue)
                                        .Select(x => JsonSerializer.Deserialize<TValue>(x.ToString()))
                                        .ToList();

                var totalCount = await database.ListLengthAsync(keyHash);

                var pagination = new PaginationResponse<TValue>()
                {
                    TotalCount = (int)totalCount,
                    Values = values
                };

                return (true, pagination);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Attempts to retrieve all paginated values from a Redis list for a specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the values to retrieve.</typeparam>
        /// <param name="project">The project identifier.</param>
        /// <param name="container">The container identifier.</param>
        /// <param name="key">The key within the Redis database to retrieve the paginated values.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A tuple indicating if the operation was successful and the retrieved values.</returns>
        public override async Task<(bool isSuccessful, IEnumerable<TValue> values)> TryPaginationGetAllAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container, key);

                var redisValues = await database.ListRangeAsync(keyHash);
                var values = redisValues.Where(x => x.HasValue)
                                        .Select(x => JsonSerializer.Deserialize<TValue>(x.ToString()));
                return (true, values);
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
