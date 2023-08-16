using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for common cache operations related to various entities.
    /// </summary>
    public class CommonCacheService : ICommonCacheService
    {
        /// <summary>
        /// Gets the hash-based cache for currency responses.
        /// </summary>
        public IOneHashRepositoryCache<Guid, CurrencyResponse> HashCurrencies { get; private set; }

        /// <summary>
        /// Gets the pagination-based cache for currency responses.
        /// </summary>
        public IOnePaginationRepositoryCache<CurrencyResponse> PaginationCurrencies { get; private set; }

        /// <summary>
        /// Gets the hash-based cache for country responses.
        /// </summary>
        public IOneHashRepositoryCache<Guid, CountryResponse> HashCountries { get; private set; }

        /// <summary>
        /// Gets the pagination-based cache for country responses.
        /// </summary>
        public IOnePaginationRepositoryCache<CountryResponse> PaginationCountries { get; private set; }

        /// <summary>
        /// Gets the hash-based cache for language responses.
        /// </summary>
        public IOneHashRepositoryCache<Guid, LanguageResponse> HashLanguages { get; private set; }

        /// <summary>
        /// Gets the pagination-based cache for language responses.
        /// </summary>
        public IOnePaginationRepositoryCache<LanguageResponse> PaginationLanguages { get; private set; }

        /// <summary>
        /// Initializes a new instance of the CommonCacheService class.
        /// </summary>
        /// <param name="cacheService">The cache service instance used for cache operations.</param>
        public CommonCacheService(ICacheService cacheService)
        {
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

            HashLanguages = new OneHashRepositoryCache<Guid, LanguageResponse>(cacheService,
                                                                              nameof(CommonCacheService),
                                                                              nameof(HashLanguages),
                                                                              TimeSpan.FromDays(1));
            PaginationLanguages = new OnePaginationRepositoryCache<LanguageResponse>(cacheService,
                                                                                    nameof(CommonCacheService),
                                                                                    nameof(PaginationLanguages),
                                                                                    TimeSpan.FromDays(1));
        }
    }
}
