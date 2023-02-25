﻿namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IValueRepositoryCache<TValue> : IRepositoryCache
    {
        Task<bool> TryExistsAsync(CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync(TValue value, CancellationToken cancellationToken = default);
        Task<IValuesCache<TValue>> TryGetAsync(CancellationToken cancellationToken = default);
    }
}
