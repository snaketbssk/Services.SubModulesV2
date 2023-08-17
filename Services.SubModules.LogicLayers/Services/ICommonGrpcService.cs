using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service class that interacts with gRPC services for common functionalities.
    /// </summary>
    public interface ICommonGrpcService
    {
        /// <summary>
        /// Retrieves currency information asynchronously.
        /// </summary>
        /// <param name="mapping">Mapping instance for converting data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting CurrencyCommonGrpcResponse.</returns>
        Task<(bool isSuccessful, CurrencyCommonGrpcResponse?)> GetCurrencyAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of currencies asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting CurrenciesCommonGrpcResponse.</returns>
        Task<(bool isSuccessful, CurrenciesCommonGrpcResponse?)> GetCurrenciesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves country information asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<(bool isSuccessful, CountryCommonGrpcResponse?)> GetCountryAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of countries asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting CountriesCommonGrpcResponse.</returns>
        Task<(bool isSuccessful, CountriesCommonGrpcResponse?)> GetCountriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves language information asynchronously.
        /// </summary>
        /// <param name="mapping">Mapping instance for converting data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting LanguageCommonGrpcResponse.</returns>
        Task<(bool isSuccessful, LanguageCommonGrpcResponse?)> GetLanguageAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of languages asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting LanguagesCommonGrpcResponse.</returns>
        Task<(bool isSuccessful, LanguagesCommonGrpcResponse?)> GetLanguagesAsync(CancellationToken cancellationToken = default);
    }
}
