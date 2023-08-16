using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Models.Mappings.Entities;
using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service class for common entity-related functionalities.
    /// </summary>
    public class CommonService : BaseService, ICommonService
    {
        private readonly ICommonCacheService _commonCacheService;
        private readonly ICommonGrpcService _commonGrpcService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">HTTP context accessor.</param>
        /// <param name="commonCacheService">Common cache service instance.</param>
        /// <param name="commonGrpcService">Common gRPC service instance.</param>
        /// <param name="mapper">AutoMapper instance.</param>
        public CommonService(
            IHttpContextAccessor httpContextAccessor,
            ICommonCacheService commonCacheService,
            ICommonGrpcService commonGrpcService,
            IMapper mapper)
            : base(httpContextAccessor)
        {
            _commonCacheService = commonCacheService;
            _commonGrpcService = commonGrpcService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves currency information asynchronously.
        /// </summary>
        /// <param name="request">ID request for the currency.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The currency response.</returns>
        public async Task<ICurrencyResponse> GetCurrencyAsync(IIdRequest request, CancellationToken cancellationToken = default)
        {
            var (cacheIsSuccessful, result) = await _commonCacheService.HashCurrencies.TryGetAsync(request.Id, cancellationToken);

            if (!cacheIsSuccessful)
            {
                // Map request to gRPC mapping
                var mapping = new CurrencyCommonGrpcRequestMapping(request.Id);

                // Retrieve currency data from gRPC service
                var (grpcIsSuccessful, currencyCommonGrpcResponse) = await _commonGrpcService.GetCurrencyAsync(mapping, cancellationToken);

                if (grpcIsSuccessful)
                {
                    // Map gRPC response to currency response
                    result = _mapper.Map<CurrencyResponse>(currencyCommonGrpcResponse);
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieves a list of currencies asynchronously.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A collection of currency responses.</returns>
        public async Task<IEnumerable<ICurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            var (cacheIsSuccessful, result) = await _commonCacheService.PaginationCurrencies.TryGetAllAsync(cancellationToken);

            if (!cacheIsSuccessful)
            {
                // Retrieve currency data from gRPC service
                var (grpcIsSuccessful, currenciesCommonGrpcResponse) = await _commonGrpcService.GetCurrenciesAsync(cancellationToken);

                if (grpcIsSuccessful && currenciesCommonGrpcResponse is not null)
                {
                    // Map gRPC response to a collection of currency responses
                    result = _mapper.Map<List<CurrencyResponse>>(currenciesCommonGrpcResponse.Values);
                }
            }

            return result;
        }
    }
}
