using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Service for interacting with wallet-related gRPC methods.
    /// Implements the <see cref="IWalletsGrpcService"/> interface.
    /// </summary>
    public class WalletsGrpcService : GrpcService, IWalletsGrpcService
    {
        private readonly ILogger<WalletsGrpcService> _logger;
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletsGrpcService"/> class.
        /// </summary>
        /// <param name="exceptionService">The exception service for handling errors.</param>
        /// <param name="tokenService">The token service for obtaining authentication tokens.</param>
        /// <param name="logger">The logger for logging events.</param>
        public WalletsGrpcService(IExceptionService exceptionService,
                                  ITokenService tokenService,
                                  ILogger<WalletsGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().WALLETS_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Credits the wallet asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">An instance of IMapping&lt;WalletTransactionWalletsGrpcRequest&gt; used for mapping.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, returning a tuple containing the success status and the IdGrpcModel result.</returns>
        public async Task<(bool isSuccessful, IdGrpcModel?)> CreditWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Debits the wallet asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">An instance of IMapping&lt;WalletTransactionWalletsGrpcRequest&gt; used for mapping.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, returning a tuple containing the success status and the IdGrpcModel result.</returns>
        public async Task<(bool isSuccessful, IdGrpcModel?)> DebitWalletAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Credits a user's wallet asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">An instance of IMapping&lt;UserTransactionWalletsGrpcRequest&gt; used for mapping.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, returning a tuple containing the success status and the IdGrpcModel result.</returns>
        public async Task<(bool isSuccessful, IdGrpcModel?)> CreditUserAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Debits a user's wallet asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">An instance of IMapping&lt;UserTransactionWalletsGrpcRequest&gt; used for mapping.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, returning a tuple containing the success status and the IdGrpcModel result.</returns>
        public async Task<(bool isSuccessful, IdGrpcModel?)> DebitUserAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
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

        /// <summary>
        /// Updates the state of a transaction asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">An instance of IMapping&lt;UpdateTransactionWalletsGrpcRequest&gt; used for mapping.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, returning a boolean indicating the success status.</returns>
        public async Task<bool> UpdateStateAsync(IMapping<UpdateTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.UpdateStateAsync(request: request,
                                                           headers: headers,
                                                           deadline: deadline,
                                                           cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(UpdateStateAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        /// <summary>
        /// Creates a wallet order asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">An instance of IMapping&lt;WalletTransactionWalletsGrpcRequest&gt; used for mapping.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, returning a tuple containing the success status and the IdGrpcModel result.</returns>
        public async Task<(bool isSuccessful, IdGrpcModel?)> CreateWalletOrderAsync(IMapping<WalletTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.CreateWalletOrderAsync(request: request,
                                                                 headers: headers,
                                                                 deadline: deadline,
                                                                 cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(CreateWalletOrderAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Creates a user order asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">An instance of IMapping&lt;UserTransactionWalletsGrpcRequest&gt; used for mapping.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, returning a tuple containing the success status and the IdGrpcModel result.</returns>
        public async Task<(bool isSuccessful, IdGrpcModel?)> CreateUserOrderAsync(IMapping<UserTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.CreateUserOrderAsync(request: request,
                                                               headers: headers,
                                                               deadline: deadline,
                                                               cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(CreateUserOrderAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Updates the state of an order asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">An instance of IMapping&lt;UpdateTransactionWalletsGrpcRequest&gt; used for mapping.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, returning a boolean indicating the success status.</returns>
        public async Task<bool> UpdateStateOrderAsync(IMapping<UpdateTransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new WalletsGrpc.WalletsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.UpdateStateOrderAsync(request: request,
                                                                headers: headers,
                                                                deadline: deadline,
                                                                cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(WalletsGrpcService),
                                                     path: nameof(UpdateStateOrderAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
