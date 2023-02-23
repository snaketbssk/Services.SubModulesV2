using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public abstract class BaseRepositoryCache<TKey, TValue> : IRepositoryCache<TKey, TValue>
    {
        public string Project { get; private set; }
        public string Container { get; private set; }
        public TimeSpan? Expiry { get; private set; }

        protected BaseRepositoryCache(string project, string container, TimeSpan? expiry)
        {
            Project = project;
            Container = container;
            Expiry = expiry;
        }

        public abstract Task<bool> TryExistsAsync(TKey key, CancellationToken cancellationToken = default);
        public abstract Task<bool> TryRemoveAsync(TKey key, CancellationToken cancellationToken = default);
        public abstract Task<bool> TrySetAsync(TKey key, TValue value, CancellationToken cancellationToken = default);
        public abstract Task<IValueCache<TValue>> TryGetAsync(TKey key, CancellationToken cancellationToken = default);
    }
}
