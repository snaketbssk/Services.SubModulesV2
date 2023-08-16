using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;
using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for managing identity-related data in cache.
    /// Implements the <see cref="IIdentityCacheService"/> interface.
    /// </summary>
    public class IdentityCacheService : IIdentityCacheService
    {
        /// <summary>
        /// Gets a repository for caching user-related data.
        /// </summary>
        public IManyValueRepositoryCache<string, UserRedis> Users { get; private set; }

        /// <summary>
        /// Gets a repository for caching session-related data.
        /// </summary>
        public IManyValueRepositoryCache<string, string> Sessions { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityCacheService"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service used for caching operations.</param>
        public IdentityCacheService(ICacheService cacheService)
        {
            // Initialize the Users cache repository.
            Users = new ManyValueRepositoryCache<string, UserRedis>(cacheService,
                nameof(IdentityCacheService),
                nameof(Users),
                TimeSpan.FromMinutes(10)); // Cache data for 10 minutes.

            // Initialize the Sessions cache repository.
            Sessions = new ManyValueRepositoryCache<string, string>(cacheService,
                nameof(IdentityCacheService),
                nameof(Sessions),
                TimeSpan.FromDays(1)); // Cache data for 1 day.
        }
    }
}
