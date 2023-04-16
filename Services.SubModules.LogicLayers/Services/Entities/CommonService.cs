using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Models.Mappings.Entities;
using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class CommonService : BaseService, ICommonService
    {
        private readonly ICommonCacheService _commonCacheService;
        private readonly ICommonGrpcService _commonGrpcService;
        private readonly IMapper _mapper;

        public CommonService(IHttpContextAccessor httpContextAccessor,
                             ICommonCacheService commonCacheService,
                             ICommonGrpcService commonGrpcService,
                             IMapper mapper)
            : base(httpContextAccessor)
        {
            _commonCacheService = commonCacheService;
            _commonGrpcService = commonGrpcService;
            _mapper = mapper;
        }

        public async Task<ICurrencyResponse> GetCurrencyAsync(IIdRequest request, CancellationToken cancellationToken = default)
        {
            var (cacheIsSuccessful, result) = await _commonCacheService.HashCurrencies.TryGetAsync(request.Id, cancellationToken);
            if (!cacheIsSuccessful)
            {
                var mapping = new CurrencyCommonGrpcRequestMapping(request.Id);
                var (grpcIsSuccessful, currencyCommonGrpcResponse) = await _commonGrpcService.GetCurrencyAsync(mapping, cancellationToken);
                if (grpcIsSuccessful)
                    result = _mapper.Map<CurrencyResponse>(currencyCommonGrpcResponse);
            }

            return result;
        }

        public async Task<IEnumerable<ICurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            var (cacheIsSuccessful, result) = await _commonCacheService.PaginationCurrencies.TryGetAllAsync(cancellationToken);
            if (!cacheIsSuccessful)
            {
                var (grpcIsSuccessful, currenciesCommonGrpcResponse) = await _commonGrpcService.GetCurrenciesAsync(cancellationToken);
                if (grpcIsSuccessful && currenciesCommonGrpcResponse is not null)
                    result = _mapper.Map<List<CurrencyResponse>>(currenciesCommonGrpcResponse.Values);
            }

            return result;
        }
    }
}
