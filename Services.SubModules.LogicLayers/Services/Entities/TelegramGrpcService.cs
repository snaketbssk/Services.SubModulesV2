using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class TelegramGrpcService : GrpcService, ITelegramGrpcService
    {
        private readonly ILogger<TelegramGrpcService> _logger;
        public TelegramGrpcService(
            ITokenService tokenService,
            ILogger<TelegramGrpcService> logger)
            : base(GrpcConfiguration<GrpcRoot>.Instance.Root.TelegramUrlGrpc, tokenService)
        {
            _logger = logger;
        }
        public async Task<MessageTelegramGrpcResponse> ExecuteAsync(IMapping<MessageTelegramGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new TelegramGrpc.TelegramGrpcClient(GrpcChannel);
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
                var result = new MessageTelegramGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }
        public async Task<MediaFilesGrpcResponse> ExecuteAsync(IMapping<MediaFilesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new TelegramGrpc.TelegramGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.SendMediaAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.StackTrace);
                var result = new MediaFilesGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }
    }
}
