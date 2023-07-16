using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICommonCacheService
    {
        IOneHashRepositoryCache<Guid, CurrencyResponse> HashCurrencies { get; }
        IOnePaginationRepositoryCache<CurrencyResponse> PaginationCurrencies { get; }
        IOneHashRepositoryCache<Guid, CountryResponse> HashCountries { get; }
        IOnePaginationRepositoryCache<CountryResponse> PaginationCountries { get; }
        IOneHashRepositoryCache<Guid, LanguageResponse> HashLanguages { get; }
        IOnePaginationRepositoryCache<LanguageResponse> PaginationLanguages { get; }
    }
}
