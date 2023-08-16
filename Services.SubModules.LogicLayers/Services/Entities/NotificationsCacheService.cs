namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Provides caching functionality for notifications-related data.
    /// Implements the INotificationsCacheService interface.
    /// </summary>
    public class NotificationsCacheService : INotificationsCacheService
    {
        private readonly ICacheService _cacheService; // Cache service instance for data caching.

        /// <summary>
        /// Initializes a new instance of the NotificationsCacheService class.
        /// </summary>
        /// <param name="cacheService">The cache service used for data caching.</param>
        public NotificationsCacheService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
    }
}
