using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service class that interacts with gRPC services for common functionalities.
    /// </summary>
    public class CommonGrpcService : GrpcService, ICommonGrpcService
    {
        private readonly ILogger<CommonGrpcService> _logger;
        private readonly IExceptionService _exceptionService;
        private readonly ICommonCacheService _commonCacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonGrpcService"/> class.
        /// </summary>
        /// <param name="exceptionService">Exception service instance.</param>
        /// <param name="tokenService">Token service instance.</param>
        /// <param name="logger">Logger instance.</param>
        /// <param name="commonCacheService">Common cache service instance.</param>
        public CommonGrpcService(IExceptionService exceptionService,
                                 ITokenService tokenService,
                                 ILogger<CommonGrpcService> logger,
                                 ICommonCacheService commonCacheService)
                                 : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().COMMON_HOST, 
                                        tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
            _commonCacheService = commonCacheService;
        }

        /// <summary>
        /// Retrieves currency information asynchronously.
        /// </summary>
        /// <param name="mapping">Mapping instance for converting data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting CurrencyCommonGrpcResponse.</returns>
        public async Task<(bool isSuccessful, CurrencyCommonGrpcResponse?)> GetCurrencyAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new CommonGrpc.CommonGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.GetCurrencyAsync(request: request,
                                                           headers: headers,
                                                           deadline: deadline,
                                                           cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(CommonGrpcService),
                                                     path: nameof(GetCurrencyAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Retrieves a list of currencies asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting CurrenciesCommonGrpcResponse.</returns>
        public async Task<(bool isSuccessful, CurrenciesCommonGrpcResponse?)> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new CommonGrpc.CommonGrpcClient(GrpcChannel);
                var request = new Empty();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.GetCurrenciesAsync(request: request,
                                                             headers: headers,
                                                             deadline: deadline,
                                                             cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(CommonGrpcService),
                                                     path: nameof(GetCurrenciesAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Retrieves country information asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        public async Task<(bool isSuccessful, CountryCommonGrpcResponse?)> GetCountryAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new CommonGrpc.CommonGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.GetCountryAsync(request: request,
                                                           headers: headers,
                                                           deadline: deadline,
                                                           cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(CommonGrpcService),
                                                     path: nameof(GetCountryAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Retrieves a list of countries asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting CountriesCommonGrpcResponse.</returns>
        public async Task<(bool isSuccessful, CountriesCommonGrpcResponse?)> GetCountriesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new CommonGrpc.CommonGrpcClient(GrpcChannel);
                var request = new Empty();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.GetCountriesAsync(request: request,
                                                             headers: headers,
                                                             deadline: deadline,
                                                             cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(CommonGrpcService),
                                                     path: nameof(GetCountriesAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Retrieves language information asynchronously.
        /// </summary>
        /// <param name="mapping">Mapping instance for converting data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting LanguageCommonGrpcResponse.</returns>
        public async Task<(bool isSuccessful, LanguageCommonGrpcResponse?)> GetLanguageAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new CommonGrpc.CommonGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.GetLanguageAsync(request: request,
                                                           headers: headers,
                                                           deadline: deadline,
                                                           cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(CommonGrpcService),
                                                     path: nameof(GetLanguageAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Retrieves a list of languages asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating if the operation was successful and the resulting LanguagesCommonGrpcResponse.</returns>
        public async Task<(bool isSuccessful, LanguagesCommonGrpcResponse?)> GetLanguagesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new CommonGrpc.CommonGrpcClient(GrpcChannel);
                var request = new Empty();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.GetLanguagesAsync(request: request,
                                                             headers: headers,
                                                             deadline: deadline,
                                                             cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(CommonGrpcService),
                                                     path: nameof(GetLanguagesAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }
    }
}
