using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IOneRepositoryCache : IRepositoryCache
    {
        Task<bool> TryExistsAsync(CancellationToken cancellationToken = default);
        Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default);
    }
}
