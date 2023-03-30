namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IHashRepositoryCache<TKey, TValue> : IRepositoryCache
    {
        Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default);

        Task<bool> TrySetAsync(IDictionary<TKey, TValue> values, CancellationToken cancellationToken = default);

        Task<(bool isSuccessful, TValue value)> TryGetAsync(TKey key, CancellationToken cancellationToken = default);

        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(CancellationToken cancellationToken = default);
    }
}
