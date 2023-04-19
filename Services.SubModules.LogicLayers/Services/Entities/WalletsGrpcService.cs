using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class WalletsGrpcService : GrpcService, IWalletsGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<WalletsGrpcService> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        public WalletsGrpcService(IExceptionService exceptionService,
                                  ITokenService tokenService,
                                  ILogger<WalletsGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().WALLETS_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        public async Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> CreditAsync(IMapping<TransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.CreditAsync(request: request,
                                                      headers: GetHeaders(),
                                                      deadline: GetDeadline(),
                                                      cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(CreditAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        public async Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> DebitAsync(IMapping<TransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.DebitAsync(request: request,
                                                     headers: GetHeaders(),
                                                     deadline: GetDeadline(),
                                                     cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(CreditAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }
    }
}
