using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class ReferralsGrpcService : GrpcService, IReferralsGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<IdentityGrpcService> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        public ReferralsGrpcService(IExceptionService exceptionService,
                                    ITokenService tokenService,
                                    ILogger<IdentityGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().REFERRALS_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

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
