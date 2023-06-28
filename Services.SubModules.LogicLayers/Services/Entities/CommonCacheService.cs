using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class CommonCacheService : ICommonCacheService
    {
        public IOneValueRepositoryCache<bool> UpdateCache { get; private set; }
        public IOneHashRepositoryCache<Guid, CurrencyResponse> HashCurrencies { get; private set; }
        public IOnePaginationRepositoryCache<CurrencyResponse> PaginationCurrencies { get; private set; }
        public IOneHashRepositoryCache<Guid, CountryResponse> HashCountries { get; private set; }
        public IOnePaginationRepositoryCache<CountryResponse> PaginationCountries { get; private set; }

        public CommonCacheService(ICacheService cacheService)
        {
            UpdateCache = new OneValueRepositoryCache<bool>(cacheService,
                                                       nameof(CommonCacheService),
                                                       nameof(UpdateCache),
                                                       TimeSpan.FromMinutes(1));
            HashCurrencies = new OneHashRepositoryCache<Guid, CurrencyResponse>(cacheService,
                                                                             nameof(CommonCacheService),
                                                                             nameof(HashCurrencies),
                                                                             TimeSpan.FromDays(1));
            PaginationCurrencies = new OnePaginationRepositoryCache<CurrencyResponse>(cacheService,
                                                                                      nameof(CommonCacheService),
                                                                                      nameof(PaginationCurrencies),
                                                                                      TimeSpan.FromDays(1));
            HashCountries = new OneHashRepositoryCache<Guid, CountryResponse>(cacheService,
                                                                              nameof(CommonCacheService),
                                                                              nameof(HashCountries),
                                                                              TimeSpan.FromDays(1));
            PaginationCountries = new OnePaginationRepositoryCache<CountryResponse>(cacheService,
                                                                                    nameof(CommonCacheService),
                                                                                    nameof(PaginationCountries),
                                                                                    TimeSpan.FromDays(1));
        }
    }
}
