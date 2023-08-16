namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for caching storage-related data.
    /// </summary>
    public class StorageCacheService : IStorageCacheService
    {
        /// <summary>
        /// Initializes a new instance of the StorageCacheService class.
        /// </summary>
        /// <param name="cacheService">The cache service to use for caching operations.</param>
        public StorageCacheService(ICacheService cacheService)
        {
        }
    }
}
