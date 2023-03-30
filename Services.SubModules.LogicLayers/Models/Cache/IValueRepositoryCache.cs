﻿namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IValueRepositoryCache<TValue> : IRepositoryCache
    {
        Task<(bool isSuccessful, TValue value)> TryGetAsync(CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync(TValue value, CancellationToken cancellationToken = default);
    }
}
