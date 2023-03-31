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
        Task<(bool isSuccessful, IEnumerable<TValue> values, int totalCount)> TryPaginationGetAsync<TValue>(string project, string container, int numberPage, int sizePage, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryPaginationGetAllAsync<TValue>(string project, string container, CancellationToken cancellationToken = default);

        Task<bool> TryPaginationSetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IEnumerable<TValue> values, int totalCount)> TryPaginationGetAsync<TKey, TValue>(string project, string container, TKey key, int numberPage, int sizePage, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryPaginationGetAllAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);
    }
}
