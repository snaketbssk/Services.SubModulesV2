using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a gRPC service for identity-related operations.
    /// Implements the <see cref="IIdentityGrpcService"/> interface.
    /// </summary>
    public class IdentityGrpcService : GrpcService, IIdentityGrpcService
    {
        /// <summary>
        /// The logger instance used for logging in this service.
        /// </summary>
        private readonly ILogger<IdentityGrpcService> _logger;

        /// <summary>
        /// The exception service used for handling exceptions.
        /// </summary>
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityGrpcService"/> class.
        /// </summary>
        /// <param name="exceptionService">The exception service used for handling exceptions.</param>
        /// <param name="tokenService">The token service for managing authentication tokens.</param>
        /// <param name="logger">The logger instance used for logging.</param>
        public IdentityGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<IdentityGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().IDENTITY_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Authenticates a user's identity using gRPC.
        /// </summary>
        /// <param name="mapping">The mapping containing authentication identity data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating success and the resulting gRPC response.</returns>
        public async Task<(bool isSuccessful, UserIdentityGrpcResponse?)> AuthenticationAsync(IMapping<AuthenticationIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new IdentityGrpc.IdentityGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.AuthenticationAsync(request: request,
                                                              headers: headers,
                                                              deadline: deadline,
                                                              cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(IdentityGrpcService),
                                                     path: nameof(AuthenticationAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Retrieves user identity data using gRPC.
        /// </summary>
        /// <param name="mapping">The mapping containing user identity ID data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A tuple indicating success and the resulting gRPC response.</returns>
        public async Task<(bool isSuccessful, UserIdentityGrpcResponse?)> GetUserAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new IdentityGrpc.IdentityGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.GetUserAsync(request: request,
                                                       headers: headers,
                                                       deadline: deadline,
                                                       cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(IdentityGrpcService),
                                                     path: nameof(GetUserAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        /// <summary>
        /// Adds roles to a user using gRPC.
        /// </summary>
        /// <param name="mapping">The mapping containing user ID and roles data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public async Task<bool> AddRolesToUserAsync(IMapping<AddRolesUserIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new IdentityGrpc.IdentityGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.AddRolesToUserAsync(request: request,
                                                              headers: headers,
                                                              deadline: deadline,
                                                              cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(IdentityGrpcService),
                                                     path: nameof(AddRolesToUserAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
