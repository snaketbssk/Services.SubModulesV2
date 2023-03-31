using Services.SubModules.LogicLayers.Models.Cache;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ITelegramCacheService
    {
        IOneRepositoryCache<bool> Outgoing { get; }
    }
}
