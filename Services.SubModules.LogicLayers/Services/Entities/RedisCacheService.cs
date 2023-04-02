using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using StackExchange.Redis;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class RedisCacheService : BaseCacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private bool isDispose { get; set; }

        protected RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public static ICacheService Initialization()
        {
            try
            {
                var root = RedisEnvironmentConfiguration<RedisEnvironmentRoot>.Instance.GetRoot();
                var connectionMultiplexer = ConnectionMultiplexer.Connect(root.CONNECTION);
                var result = new RedisCacheService(connectionMultiplexer);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async void Dispose()
        {
            if (!isDispose && _connectionMultiplexer is not null)
            {
                isDispose = true;
                await _connectionMultiplexer.CloseAsync();
            }
        }

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
