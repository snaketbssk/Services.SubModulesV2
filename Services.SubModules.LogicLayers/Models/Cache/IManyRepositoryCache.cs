namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IManyRepositoryCache<TKey, TValue> : IRepositoryCache
    {
        Task<(bool isSuccessful, TValue value)> TryGetAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default);
    }
}
