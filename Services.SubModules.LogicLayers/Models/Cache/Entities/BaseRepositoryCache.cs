using Services.SubModules.LogicLayers.Services;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    /// <summary>
    /// Base class for repository cache entities.
    /// </summary>
    public abstract class BaseRepositoryCache : IRepositoryCache
    {
        /// <summary>
        /// Gets the project associated with the cache.
        /// </summary>
        public string Project { get; private set; }

        /// <summary>
        /// Gets the container associated with the cache.
        /// </summary>
        public string Container { get; private set; }

        /// <summary>
        /// Gets the expiration duration for cached items.
        /// </summary>
        public TimeSpan? Expiry { get; private set; }

        /// <summary>
        /// Gets the cache service used for handling caching operations.
        /// </summary>
        public ICacheService CacheService { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepositoryCache"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service to be used.</param>
        /// <param name="project">The project associated with the cache.</param>
        /// <param name="container">The container associated with the cache.</param>
        /// <param name="expiry">The expiration duration for cached items.</param>
        protected BaseRepositoryCache(ICacheService cacheService, string project, string container, TimeSpan? expiry)
        {
            Project = project?.ToUpper() ?? throw new ArgumentNullException(nameof(project));
            Container = container?.ToUpper() ?? throw new ArgumentNullException(nameof(container));
            Expiry = expiry;
            CacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }
    }
}
