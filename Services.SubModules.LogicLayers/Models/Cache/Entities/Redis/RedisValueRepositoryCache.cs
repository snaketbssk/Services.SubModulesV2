using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities.Redis
{
    public class RedisValueRepositoryCache<TValue> : BaseValueRepositoryCache<TValue>
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisValueRepositoryCache(IConnectionMultiplexer connectionMultiplexer, string project, string container, TimeSpan? expiry)
            : base(project, container, expiry)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        private string GetKeyHash()
        {
            var result = $"{Project}-{Container}";
            return result;
        }

        public override async Task<bool> TryExistsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash();
                var result = await database.KeyExistsAsync(keyHash);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<IValuesCache<TValue>> TryGetAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash();
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

        public override async Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash();
                var result = await database.KeyDeleteAsync(keyHash);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> TrySetAsync(TValue value, CancellationToken cancellationToken = default)
        {
            if (value is null)
                return false;

            try
            {
                var database = _connectionMultiplexer.GetDatabase();
                var keyHash = GetKeyHash();
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
