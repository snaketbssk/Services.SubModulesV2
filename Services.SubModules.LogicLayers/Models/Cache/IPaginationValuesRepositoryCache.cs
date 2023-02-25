namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IPaginationValuesRepositoryCache<TKey, TValue> : IRepositoryCache
    {
        Task<bool> TryExistsAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync(TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default);
        Task<IPaginationCache<TValue>> TryGetAsync(TKey key, int numberPage, int sizePage, CancellationToken cancellationToken = default);
    }
}
