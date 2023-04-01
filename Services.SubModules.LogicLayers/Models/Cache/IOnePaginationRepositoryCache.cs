namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IOnePaginationRepositoryCache<TValue> : IOneRepositoryCache
    {
        Task<bool> TrySetAsync(IEnumerable<TValue> values, CancellationToken cancellationToken = default);

        Task<(bool isSuccessful, IEnumerable<TValue> values, int totalCount)> TryGetAsync(int numberPage, int sizePage, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, IEnumerable<TValue> values)> TryGetAllAsync(CancellationToken cancellationToken = default);
    }
}
