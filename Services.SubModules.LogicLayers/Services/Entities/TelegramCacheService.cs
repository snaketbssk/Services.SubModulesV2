using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class TelegramCacheService : ITelegramCacheService
    {
        public IOneRepositoryCache<bool> Outgoing { get; private set; }

        public TelegramCacheService(ICacheService cacheService)
        {
            Outgoing = new OneRepositoryCache<bool>(cacheService,
                                                     nameof(TelegramCacheService),
                                                     nameof(Outgoing),
                                                     TimeSpan.FromMinutes(1));
        }
    }
}
