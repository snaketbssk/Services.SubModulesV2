using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public abstract class BaseRepositoryCache : IRepositoryCache
    {
        public string Project { get; private set; }
        public string Container { get; private set; }
        public TimeSpan? Expiry { get; private set; }
        public ICacheService CacheService { get; private set; }

        protected BaseRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
        {
            Project = project?.ToUpper() ?? throw new ArgumentNullException(nameof(project));
            Container = container?.ToUpper() ?? throw new ArgumentNullException(nameof(container));
            Expiry = expiry;
            CacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }
    }
}
