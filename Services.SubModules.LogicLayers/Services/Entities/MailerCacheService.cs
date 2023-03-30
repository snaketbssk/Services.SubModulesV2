using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class MailerCacheService : IMailerCacheService
    {
        public IValueRepositoryCache<bool> Outgoing { get; private set; }

        public MailerCacheService(ICacheService cacheService)
        {
            Outgoing = new ValueRepositoryCache<bool>(cacheService,
                                                      nameof(MailerCacheService),
                                                      nameof(Outgoing),
                                                      TimeSpan.FromMinutes(1));
        }
    }
}
