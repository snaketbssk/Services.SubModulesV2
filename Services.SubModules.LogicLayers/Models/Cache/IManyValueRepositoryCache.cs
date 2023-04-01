namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IManyValueRepositoryCache<TKey, TValue> : IManyRepositoryCache<TKey>
    {
        Task<(bool isSuccessful, TValue value)> TryGetAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default);
    }
}
