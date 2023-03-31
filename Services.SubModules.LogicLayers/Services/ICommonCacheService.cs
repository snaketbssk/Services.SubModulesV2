using Services.SubModules.LogicLayers.Models.Cache;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICommonCacheService
    {
        IOneRepositoryCache<string> Value { get; }
        IManyRepositoryCache<string, string> Values { get; }
        IHashRepositoryCache<string, string> Hash { get; }
        IOnePaginationRepositoryCache<string> Pagination { get; }
    }
}
