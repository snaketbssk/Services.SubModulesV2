using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IIdentityCacheService
    {
        IManyValueRepositoryCache<string, UserRedis> Users { get; }
        IManyValueRepositoryCache<string, string> Sessions { get; }
    }
}
