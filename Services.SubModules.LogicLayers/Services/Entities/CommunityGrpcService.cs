using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Service for handling gRPC communication with the Community service.
    /// </summary>
    public class CommunityGrpcService : GrpcService, ICommunityGrpcService
    {
        private readonly ILogger<CommonGrpcService> _logger;
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunityGrpcService"/> class.
        /// </summary>
        /// <param name="tokenService">The token service to use for authentication.</param>
        /// <param name="logger">The logger for logging messages.</param>
        /// <param name="exceptionService">The service for handling exceptions.</param>
        public CommunityGrpcService(ITokenService tokenService,
                                    ILogger<CommonGrpcService> logger,
                                    IExceptionService exceptionService)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().COMMUNITY_HOST,
                   tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Gets currency information asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">The mapping to the request object.</param>
        /// <param name="cancellationToken">The cancellation token (optional).</param>
        /// <returns>A tuple containing a boolean indicating success and a LabelGrpcModel if successful.</returns>
        public async Task<(bool isSuccessful, LabelGrpcModel? value)> GetCurrencyAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new CommunityGrpc.CommunityGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.GetFriendAsync(request: request,
                                                         headers: headers,
                                                         deadline: deadline,
                                                         cancellationToken);
                return (true, result);
            }
            catch (Exception exception)
            {
                // Log and handle exceptions gracefully
                await _exceptionService.ExecuteAsync(method: nameof(CommonGrpcService),
                                                     path: nameof(GetCurrencyAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return (false, default);
            }
        }
    }
}
