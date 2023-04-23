﻿using Google.Protobuf.WellKnownTypes;
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
    }
}
