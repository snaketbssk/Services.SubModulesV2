using Services.SubModules.LogicLayers.Models.Cache;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICommonCacheService
    {
        IValueRepositoryCache<string> Value { get; }
        IValuesRepositoryCache<string, string> Values { get; }
        IHashRepositoryCache<string, string> Hash { get; }
        IPaginationRepositoryCache<string> Pagination { get; }
    }
}
