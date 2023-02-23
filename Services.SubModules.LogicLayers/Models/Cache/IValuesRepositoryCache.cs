using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IValuesRepositoryCache<TKey, TValue> : IRepositoryCache
    {
        Task<bool> TryExistsAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default);
        Task<IValuesCache<TValue>> TryGetAsync(TKey key, CancellationToken cancellationToken = default);
    }
}
