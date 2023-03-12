using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class TelegramGrpcService : GrpcService, ITelegramGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<TelegramGrpcService> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        public TelegramGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<TelegramGrpcService> logger)
            : base(GrpcConfiguration<GrpcRoot>.Instance.Root.TelegramUrlGrpc, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
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
                await _exceptionService.ExecuteAsync(
                    method: "TelegramGrpcService",
                    path: "SendMessageAsync",
                    exception: exception,
                    cancellationToken);
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
                await _exceptionService.ExecuteAsync(
                    method: "TelegramGrpcService",
                    path: "SendMediaFilesAsync",
                    exception: exception,
                    cancellationToken);
                var result = new MediaFilesGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }

        public async Task<MediaImagesGrpcResponse> ExecuteAsync(IMapping<MediaImagesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new TelegramGrpc.TelegramGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var result = await client.SendImagesAsync(
                    request: request,
                    headers: GetHeaders(),
                    deadline: GetDeadline(),
                    cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(
                    method: "TelegramGrpcService",
                    path: "SendMediaImagesAsync",
                    exception: exception,
                    cancellationToken);
                var result = new MediaImagesGrpcResponse
                {
                    IsSuccess = false
                };
                return result;
            }
        }
    }
}
