using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public abstract class BaseValueRepositoryCache<TValue> : IValueRepositoryCache<TValue>
    {
        public string Project { get; private set; }
        public string Container { get; private set; }
        public TimeSpan? Expiry { get; private set; }

        protected BaseValueRepositoryCache(string project, string container, TimeSpan? expiry)
        {
            Project = project;
            Container = container;
            Expiry = expiry;
        }

        public abstract Task<bool> TryExistsAsync(CancellationToken cancellationToken = default);
        public abstract Task<bool> TryRemoveAsync(CancellationToken cancellationToken = default);
        public abstract Task<bool> TrySetAsync(TValue value, CancellationToken cancellationToken = default);
        public abstract Task<IValuesCache<TValue>> TryGetAsync(CancellationToken cancellationToken = default);
    }
}
