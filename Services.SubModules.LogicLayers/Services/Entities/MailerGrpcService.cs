using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class MailerGrpcService : GrpcService, IMailerGrpcService
    {
        private readonly ILogger<MailerGrpcService> _logger;
        public MailerGrpcService(
            ITokenService tokenService,
            ILogger<MailerGrpcService> logger)
            : base(GrpcConfiguration<GrpcRoot>.Instance.Root.MailerUrlGrpc, tokenService)
        {
            _logger = logger;
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
                _logger.LogError(exception.StackTrace);
                var result = new MessageMailerGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }
    }
}
