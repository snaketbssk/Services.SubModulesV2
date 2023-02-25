using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IIdentityCacheService
    {
        IValuesRepositoryCache<string, UserRedis> User { get; }
    }
}
