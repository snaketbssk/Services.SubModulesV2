using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for managing referrals using gRPC.
    /// </summary>
    public class ReferralsGrpcService : GrpcService, IReferralsGrpcService
    {
        /// <summary>
        /// The logger instance for capturing log messages.
        /// </summary>
        private readonly ILogger<IdentityGrpcService> _logger;

        /// <summary>
        /// The service for handling exceptions.
        /// </summary>
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferralsGrpcService"/> class.
        /// </summary>
        /// <param name="exceptionService">The service for handling exceptions.</param>
        /// <param name="tokenService">The service for managing tokens.</param>
        /// <param name="logger">The logger instance.</param>
        public ReferralsGrpcService(IExceptionService exceptionService,
                                    ITokenService tokenService,
                                    ILogger<IdentityGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().REFERRALS_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Creates a new referral asynchronously.
        /// </summary>
        /// <param name="mapping">The mapping for creating a referral.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation. Returns true if successful, otherwise false.</returns>
        public async Task<bool> CreateReferralAsync(IMapping<CreateReferralReferralsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new ReferralsGrpc.ReferralsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                await client.CreateReferralAsync(request: request,
                                                 headers: headers,
                                                 deadline: deadline,
                                                 cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(ReferralsGrpcService),
                                                     path: nameof(CreateReferralAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
