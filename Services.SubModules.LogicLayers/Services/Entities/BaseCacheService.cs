using Services.SubModules.LogicLayers.Models.Cache;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public abstract class BaseCacheService : ICacheService
    {
        protected virtual string GetKeyHash(string project, string container)
        {
            var result = $"{project}-{container}";
            return result;
        }

        protected virtual string GetKeyHash<TKey>(string project, string container, TKey key)
        {
            var result = $"{project}-{container}-{key}";
            return result;
        }

        public abstract Task<bool> TryExistsAsync(string project, string container, CancellationToken cancellationToken = default);

        public abstract Task<bool> TryExistsAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        public abstract Task<bool> TryRemoveAsync(string project, string container, CancellationToken cancellationToken = default);

        public abstract Task<bool> TryRemoveAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        public abstract Task<bool> TrySetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default);

        public abstract Task<bool> TrySetAsync<TValue>(string project, string container, TimeSpan? expiry, TValue value, CancellationToken cancellationToken = default);

        public abstract Task<bool> TrySetAsync<TValue>(string project, string container, TimeSpan? expiry, IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        public abstract Task<bool> TrySetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        public abstract Task<IValuesCache<TValue>> TryGetAsync<TValue>(string project, string container, CancellationToken cancellationToken = default);

        public abstract Task<IValuesCache<TValue>> TryGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        public abstract Task<IPaginationCache<TValue>> TryGetAsync<TValue>(string project, string container, int numberPage, int sizePage, CancellationToken cancellationToken = default);

        public abstract Task<IPaginationCache<TValue>> TryGetAsync<TKey, TValue>(string project, string container, TKey key, int numberPage, int sizePage, CancellationToken cancellationToken = default);
    }
}
