using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents the interface for common cache service that provides access to various cached data.
    /// </summary>
    public interface ICommonCacheService
    {
        /// <summary>
        /// Gets the cached hash repository for CurrencyResponse objects indexed by Guid.
        /// </summary>
        IOneHashRepositoryCache<Guid, CurrencyResponse> HashCurrencies { get; }

        /// <summary>
        /// Gets the cached pagination repository for CurrencyResponse objects.
        /// </summary>
        IOnePaginationRepositoryCache<CurrencyResponse> PaginationCurrencies { get; }

        /// <summary>
        /// Gets the cached hash repository for CountryResponse objects indexed by Guid.
        /// </summary>
        IOneHashRepositoryCache<Guid, CountryResponse> HashCountries { get; }

        /// <summary>
        /// Gets the cached pagination repository for CountryResponse objects.
        /// </summary>
        IOnePaginationRepositoryCache<CountryResponse> PaginationCountries { get; }

        /// <summary>
        /// Gets the cached hash repository for LanguageResponse objects indexed by Guid.
        /// </summary>
        IOneHashRepositoryCache<Guid, LanguageResponse> HashLanguages { get; }

        /// <summary>
        /// Gets the cached pagination repository for LanguageResponse objects.
        /// </summary>
        IOnePaginationRepositoryCache<LanguageResponse> PaginationLanguages { get; }
    }
}
