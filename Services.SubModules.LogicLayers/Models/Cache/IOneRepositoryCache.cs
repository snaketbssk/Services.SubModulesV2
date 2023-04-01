namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IOneRepositoryCache : IRepositoryCache
    {
        Task<bool> TryExistsAsync(CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default);
    }
}
