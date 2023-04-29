using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICommonCacheService
    {
        IOneHashRepositoryCache<Guid, CurrencyResponse> HashCurrencies { get; }
        IOnePaginationRepositoryCache<CurrencyResponse> PaginationCurrencies { get; }
        IOneValueRepositoryCache<bool> UpdateCache { get; }
        IOneHashRepositoryCache<Guid, CountryResponse> HashCountries { get; }
        IOnePaginationRepositoryCache<CountryResponse> PaginationCountries { get; }
    }
}
