using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IRepositoryCache<TKey, TValue>
    {
        string Project { get; }
        string Container { get; }
        TimeSpan? Expiry { get; }

        Task<bool> TryExistsAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default);
        Task<IValueCache<TValue>> TryGetAsync(TKey key, CancellationToken cancellationToken = default);
    }
}
