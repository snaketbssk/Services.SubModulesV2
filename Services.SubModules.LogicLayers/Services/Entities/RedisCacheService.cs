using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;
using StackExchange.Redis;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class RedisCacheService : BaseCacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

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

        public override async Task<bool> TryExistsAsync(string project, string container, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);
                var result = await database.KeyExistsAsync(keyHash);

                return result;
            }
            catch (Exception)
            {
                return false;
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

        public override async Task<bool> TryRemoveAsync(string project, string container, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);
                var result = await database.KeyDeleteAsync(keyHash);

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

        public override async Task<bool> TrySetAsync<TValue>(string project, string container, TimeSpan? expiry, TValue value, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(value);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);
                var valueHash = JsonSerializer.Serialize(value);
                var result = await database.StringSetAsync(keyHash, valueHash, expiry);

                return result;
            }
            catch (Exception)
            {
                return false;
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

        public override async Task<bool> TrySetAsync<TValue>(string project, string container, TimeSpan? expiry, IEnumerable<TValue> values, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(values);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);

                var hashValues = values.Select(x => new RedisValue(JsonSerializer.Serialize(x))).ToArray();
                await database.ListRightPushAsync(keyHash, hashValues);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> TrySetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default)
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
                await database.ListRightPushAsync(keyHash, hashValues);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<IValuesCache<TValue>> TryGetAsync<TValue>(string project, string container, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);
                var redisValue = await database.StringGetAsync(keyHash);

                if (!redisValue.HasValue || redisValue.IsNullOrEmpty)
                    throw new ArgumentNullException(nameof(redisValue));

                var value = JsonSerializer.Deserialize<TValue>(redisValue.ToString());

                ArgumentNullException.ThrowIfNull(value);

                var result = new ValueCache<TValue>(true, value);

                return result;
            }
            catch (Exception)
            {
                return new ValueCache<TValue>(false);
            }
        }

        public override async Task<IValuesCache<TValue>> TryGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default)
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
                    throw new ArgumentNullException(nameof(redisValue));

                var value = JsonSerializer.Deserialize<TValue>(redisValue.ToString());

                ArgumentNullException.ThrowIfNull(value);

                var result = new ValueCache<TValue>(true, value);

                return result;
            }
            catch (Exception)
            {
                return new ValueCache<TValue>(false);
            }
        }

        public override async Task<IPaginationCache<TValue>> TryGetAsync<TValue>(string project, string container, int numberPage, int sizePage, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container);

                int startIndex = (numberPage - 1) * sizePage;
                int endIndex = numberPage * sizePage - 1;

                var redisValues = await database.ListRangeAsync(keyHash, startIndex, endIndex);
                var values = redisValues
                    .Where(x => x.HasValue)
                    .Select(x => JsonSerializer.Deserialize<TValue>(x.ToString()))
                    .ToList();

                var totalCount = await database.ListLengthAsync(keyHash);
                var result = new PaginationCache<TValue>(true, values, (int)totalCount);

                return result;
            }
            catch (Exception)
            {
                return new PaginationCache<TValue>(false);
            }
        }

        public override async Task<IPaginationCache<TValue>> TryGetAsync<TKey, TValue>(string project, string container, TKey key, int numberPage, int sizePage, CancellationToken cancellationToken = default)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(project);
                ArgumentNullException.ThrowIfNull(container);
                ArgumentNullException.ThrowIfNull(key);

                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(project, container, key);

                int startIndex = (numberPage - 1) * sizePage;
                int endIndex = numberPage * sizePage - 1;

                var redisValues = await database.ListRangeAsync(keyHash, startIndex, endIndex);
                var values = redisValues
                    .Where(x => x.HasValue)
                    .Select(x => JsonSerializer.Deserialize<TValue>(x.ToString()))
                    .ToList();

                var totalCount = await database.ListLengthAsync(keyHash);
                var result = new PaginationCache<TValue>(true, values, (int)totalCount);

                return result;
            }
            catch (Exception)
            {
                return new PaginationCache<TValue>(false);
            }
        }
    }
}
