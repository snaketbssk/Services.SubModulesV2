using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class MailerGrpcService : GrpcService, IMailerGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<MailerGrpcService> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenService"></param>
        /// <param name="logger"></param>
        public MailerGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<MailerGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().MAILER_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }
        public async Task<bool> SendMessageAsync(IMapping<MessageMailerGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new MailerGrpc.MailerGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.SendMessageAsync(request: request,
                                                           headers: headers,
                                                           deadline: deadline,
                                                           cancellationToken: cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(IdentityGrpcService),
                                                     path: nameof(SendMessageAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
