namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Provides caching functionality for mailer-related data.
    /// Implements the IMailerCacheService interface.
    /// </summary>
    public class MailerCacheService : IMailerCacheService
    {
        private readonly ICacheService _cacheService; // Cache service instance for data caching.

        /// <summary>
        /// Initializes a new instance of the MailerCacheService class.
        /// </summary>
        /// <param name="cacheService">The cache service used for data caching.</param>
        public MailerCacheService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
    }
}
