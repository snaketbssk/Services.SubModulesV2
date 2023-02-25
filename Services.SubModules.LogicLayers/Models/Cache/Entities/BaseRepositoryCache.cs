using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public abstract class BaseRepositoryCache
    {
        public string Project { get; private set; }
        public string Container { get; private set; }
        public TimeSpan? Expiry { get; private set; }
        public ICacheService CacheService { get; private set; }

        protected BaseRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
        {
            Project = project;
            Container = container;
            Expiry = expiry;
            CacheService = cacheService;
        }
    }
}
