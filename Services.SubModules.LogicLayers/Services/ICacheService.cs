using Services.SubModules.LogicLayers.Models.Cache;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICacheService
    {
        Task<bool> TryExistsAsync(string project, string container, CancellationToken cancellationToken = default);

        Task<bool> TryExistsAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        Task<bool> TryRemoveAsync(string project, string container, CancellationToken cancellationToken = default);

        Task<bool> TryRemoveAsync<TKey>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        Task<bool> TrySetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, TValue value, CancellationToken cancellationToken = default);

        Task<bool> TrySetAsync<TValue>(string project, string container, TimeSpan? expiry, TValue value, CancellationToken cancellationToken = default);

        Task<bool> TrySetAsync<TValue>(string project, string container, TimeSpan? expiry, IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        Task<bool> TrySetAsync<TKey, TValue>(string project, string container, TimeSpan? expiry, TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        Task<IValuesCache<TValue>> TryGetAsync<TValue>(string project, string container, CancellationToken cancellationToken = default);

        Task<IValuesCache<TValue>> TryGetAsync<TKey, TValue>(string project, string container, TKey key, CancellationToken cancellationToken = default);

        Task<IPaginationCache<TValue>> TryGetAsync<TValue>(string project, string container, int numberPage, int sizePage, CancellationToken cancellationToken = default);

        Task<IPaginationCache<TValue>> TryGetAsync<TKey, TValue>(string project, string container, TKey key, int numberPage, int sizePage, CancellationToken cancellationToken = default);
    }
}
