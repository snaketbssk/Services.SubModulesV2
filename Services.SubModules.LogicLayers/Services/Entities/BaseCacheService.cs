namespace Services.SubModules.LogicLayers.Services.Entities
{
    public abstract class BaseCacheService : ICacheService, IDisposable
    {
        public abstract void Dispose();

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

        public abstract Task<bool> TryExistsAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);
        public abstract Task<bool> TryRemoveAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        public abstract Task<(bool isSuccessful, TValue value)> TrySingleGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);
        public abstract Task<bool> TrySingleSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default);

        public abstract Task<bool> TryHashSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default);
        public abstract Task<bool> TryHashSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, IDictionary<TKey, TValue> values, CancellationToken cancellationToken = default);
        public abstract Task<(bool isSuccessful, TValue value)> TryHashGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);
        public abstract Task<(bool isSuccessful, IEnumerable<TValue> values)> TryHashGetAllAsync<TKey, TValue>(string project, string container, CancellationToken cancellationToken = default);

        public abstract Task<bool> TryPaginationSetAsync<TValue>(string project, string container, TimeSpan? expiry, IEnumerable<TValue> values, CancellationToken cancellationToken = default);
        public abstract Task<(bool isSuccessful, IEnumerable<TValue> values, int totalCount)> TryPaginationGetAsync<TValue>(string project, string container, int numberPage, int sizePage, CancellationToken cancellationToken = default);
        public abstract Task<(bool isSuccessful, IEnumerable<TValue> values)> TryPaginationGetAllAsync<TValue>(string project, string container, CancellationToken cancellationToken = default);
    }
}
