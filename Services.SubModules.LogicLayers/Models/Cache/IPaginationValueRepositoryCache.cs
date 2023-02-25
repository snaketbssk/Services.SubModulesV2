namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IPaginationValueRepositoryCache<TValue> : IRepositoryCache
    {
        Task<bool> TryExistsAsync(CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync(IEnumerable<TValue> values, CancellationToken cancellationToken = default);
        Task<IPaginationCache<TValue>> TryGetAsync(int numberPage, int sizePage, CancellationToken cancellationToken = default);
    }
}
