using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IManyRepositoryCache<TKey> : IRepositoryCache
    {
        Task<bool> TryExistsAsync(TKey key, CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync(TKey key, CancellationToken cancellationToken = default);
    }
}
