using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class IdentityGrpcService : GrpcService, IIdentityGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<IdentityGrpcService> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        public IdentityGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<IdentityGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().IDENTITY_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        public async Task<(bool isSuccessful, UserIdentityGrpcResponse?)> AuthenticationAsync(IMapping<AuthenticationIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new IdentityGrpc.IdentityGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.AuthenticationAsync(request: request,
                                                              headers: GetHeaders(),
                                                              deadline: GetDeadline(),
                                                              cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: "IdentityGrpcService",
                                                     path: "AuthenticationAsync",
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        public async Task<(bool isSuccessful, UserIdentityGrpcResponse?)> GetUserAsync(IMapping<UserIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new IdentityGrpc.IdentityGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.GetUserAsync(request: request,
                                                       headers: GetHeaders(),
                                                       deadline: GetDeadline(),
                                                       cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: "IdentityGrpcService",
                                                     path: "GetUserAsync",
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }

        public async Task<bool> AddRolesToUserAsync(IMapping<AddRolesUserIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new IdentityGrpc.IdentityGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.AddRolesToUserAsync(request: request,
                                                              headers: GetHeaders(),
                                                              deadline: GetDeadline(),
                                                              cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: "IdentityGrpcService",
                                                     path: "AddRolesToUser",
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
