using Services.SubModules.LogicLayers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public abstract class OneRepositoryCache : BaseRepositoryCache, IOneRepositoryCache
    {
        protected OneRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry) 
            : base(cacheService, project, container, expiry)
        {
        }

        public virtual async Task<bool> TryExistsAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryExistsAsync(Project, Container, string.Empty, cancellationToken);
            return result;
        }

        public virtual async Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default)
        {
            var result = await CacheService.TryRemoveAsync(Project, Container, string.Empty, cancellationToken);
            return result;
        }
    }
}
