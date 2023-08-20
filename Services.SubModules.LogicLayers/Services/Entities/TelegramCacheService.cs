namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for caching Telegram-related data.
    /// Implements the <see cref="ITelegramCacheService"/> interface.
    /// </summary>
    public class TelegramCacheService : ITelegramCacheService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramCacheService"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service used for caching data.</param>
        public TelegramCacheService(ICacheService cacheService)
        {
        }
    }
}
