namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IRepositoryCache
    {
        string Project { get; }
        string Container { get; }
        TimeSpan? Expiry { get; }

        Task<bool> TryExistsAsync<TKey>(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync<TKey>(TKey key, CancellationToken cancellationToken = default);

    }
}
