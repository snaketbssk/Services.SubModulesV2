using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

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

        public async Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> CreditWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.CreditWalletAsync(request: request,
                                                            headers: headers,
                                                            deadline: deadline,
                                                            cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(CreditWalletAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        public async Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> DebitWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.DebitWalletAsync(request: request,
                                                           headers: headers,
                                                           deadline: deadline,
                                                           cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(CreditWalletAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        public async Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> CreditUserAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.CreditUserAsync(request: request,
                                                            headers: headers,
                                                            deadline: deadline,
                                                            cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(CreditWalletAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        public async Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> DebitUserAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.DebitUserAsync(request: request,
                                                           headers: headers,
                                                           deadline: deadline,
                                                           cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(CreditWalletAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }
    }
}
