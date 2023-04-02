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
            var (isSuccessful, result) = await _commonCacheService.HashCurrencies.TryGetAsync(request.Id, cancellationToken);
            if (!isSuccessful)
            {
                var mapping = new CurrencyCommonGrpcRequestMapping(request.Id);
                var currencyCommonGrpcResponse = await _commonGrpcService.ExecuteAsync(mapping, cancellationToken);
                if (currencyCommonGrpcResponse.IsSuccess)
                    result = _mapper.Map<CurrencyResponse>(currencyCommonGrpcResponse);
            }

            return result;
        }

        public async Task<IEnumerable<ICurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            var (isSuccessful, result) = await _commonCacheService.PaginationCurrencies.TryGetAllAsync(cancellationToken);
            if (!isSuccessful)
            {
                var mapping = new CurrenciesCommonGrpcRequestMapping();
                var currenciesCommonGrpcResponse = await _commonGrpcService.ExecuteAsync(mapping, cancellationToken);
                if (currenciesCommonGrpcResponse.IsSuccess)
                    result = _mapper.Map<List<CurrencyResponse>>(currenciesCommonGrpcResponse.Values);
            }

            return result;
        }
    }
}
