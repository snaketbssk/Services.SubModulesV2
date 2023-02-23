using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities.Redis
{
    public class RedisValuesRepositoryCache<TKey, TValue> : BaseValuesRepositoryCache<TKey, TValue>
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisValuesRepositoryCache(IConnectionMultiplexer connectionMultiplexer, string project, string container, TimeSpan? expiry) 
            : base(project, container, expiry)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        private string GetKeyHash(TKey key)
        {
            var result = $"{Project}-{Container}-{key}";
            return result;
        }

        public override async Task<bool> TryExistsAsync(TKey key, CancellationToken cancellationToken = default)
        {
            if (key is null)
                return false;

            try
            {
                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(key);
                var result = await database.KeyExistsAsync(keyHash);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<IValuesCache<TValue>> TryGetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            if (key is null)
                return new ValueCache<TValue>(false);

            try
            {
                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(key);
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

        public override async Task<bool> TryRemoveAsync(TKey key, CancellationToken cancellationToken = default)
        {
            if (key is null)
                return false;

            try
            {
                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(key);
                var result = await database.KeyDeleteAsync(keyHash);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default)
        {
            if (key is null)
                return false;
            if (value is null)
                return false;

            try
            {
                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash(key);
                var valueHash = JsonSerializer.Serialize(value);
                var result = await database.StringSetAsync(keyHash, valueHash, Expiry);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
