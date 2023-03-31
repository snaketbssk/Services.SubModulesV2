namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IManyPaginationRepositoryCache<TKey, TValue> : IRepositoryCache
    {
        Task<bool> TrySetAsync(TKey key, IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        Task<(bool isSuccessful, IEnumerable<TValue> values, int totalCount)> TryGetAsync(TKey key, int numberPage, int sizePage, CancellationToken cancellationToken = default);

        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(TKey key, CancellationToken cancellationToken = default);
    }
}
