using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
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
            : base(GrpcConfiguration<GrpcRoot>.Instance.Root.MailerUrlGrpc, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }
        public async Task<MessageMailerGrpcResponse> ExecuteAsync(IMapping<MessageMailerGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new MailerGrpc.MailerGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.SendMessageAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "MailerGrpcService",
                    path: "SendMessageAsync",
                    exception: exception,
                    cancellationToken);
                var result = new MessageMailerGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }
    }
}
