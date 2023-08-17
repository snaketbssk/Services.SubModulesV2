using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing identity-related caching operations.
    /// </summary>
    public interface IIdentityCacheService
    {
        /// <summary>
        /// Gets the cache repository for storing UserRedis objects.
        /// </summary>
        IManyValueRepositoryCache<string, UserRedis> Users { get; }

        /// <summary>
        /// Gets the cache repository for storing session-related data.
        /// </summary>
        IManyValueRepositoryCache<string, string> Sessions { get; }
    }
}
