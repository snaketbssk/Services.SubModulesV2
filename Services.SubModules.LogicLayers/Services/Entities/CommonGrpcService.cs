using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class CommonGrpcService : GrpcService, ICommonGrpcService
    {
        private readonly ILogger<CommonGrpcService> _logger;
        private readonly IExceptionService _exceptionService;
        private readonly ICommonCacheService _commonCacheService;

        public CommonGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<CommonGrpcService> logger,
            ICommonCacheService commonCacheService)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().COMMON_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
            _commonCacheService = commonCacheService;
        }

        public async Task<CurrencyCommonGrpcResponse> ExecuteAsync(IMapping<CurrencyCommonGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new CommonGrpc.CommonGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.GetCurrencyAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(CommonGrpcService),
                                                     path: nameof(CommonGrpc.CommonGrpcClient.GetCurrencyAsync),
                                                     exception: exception,
                                                     cancellationToken);
                var result = new CurrencyCommonGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }

        public async Task<CurrenciesCommonGrpcResponse> ExecuteAsync(IMapping<CurrenciesCommonGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new CommonGrpc.CommonGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.GetCurrenciesAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(CommonGrpcService),
                                                     path: nameof(CommonGrpc.CommonGrpcClient.GetCurrenciesAsync),
                                                     exception: exception,
                                                     cancellationToken);
                var result = new CurrenciesCommonGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }
    }
}
