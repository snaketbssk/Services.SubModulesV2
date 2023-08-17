using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for interacting with Telegram via gRPC.
    /// Implements the <see cref="ITelegramGrpcService"/> interface.
    /// </summary>
    public class TelegramGrpcService : GrpcService, ITelegramGrpcService
    {
        private readonly ILogger<TelegramGrpcService> _logger;
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramGrpcService"/> class.
        /// </summary>
        /// <param name="exceptionService">The exception service for handling errors.</param>
        /// <param name="tokenService">The token service for obtaining authentication tokens.</param>
        /// <param name="logger">The logger for logging events.</param>
        public TelegramGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<TelegramGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().TELEGRAM_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Sends a Telegram message asynchronously via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping of the message request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><c>true</c> if the message was sent successfully; otherwise, <c>false</c>.</returns>
        public async Task<bool> SendMessageAsync(IMapping<MessageTelegramGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new TelegramGrpc.TelegramGrpcClient(GrpcChannel);
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
                await _exceptionService.ExecuteAsync(method: nameof(TelegramGrpcService),
                                                     path: nameof(SendMessageAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        /// <summary>
        /// Sends media asynchronously via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping of the media request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><c>true</c> if the media was sent successfully; otherwise, <c>false</c>.</returns>
        public async Task<bool> SendMediaAsync(IMapping<MediaFilesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new TelegramGrpc.TelegramGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.SendMediaAsync(request: request,
                                                         headers: headers,
                                                         deadline: deadline,
                                                         cancellationToken: cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(TelegramGrpcService),
                                                     path: nameof(SendMediaAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        /// <summary>
        /// Sends images asynchronously via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping of the image request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><c>true</c> if the images were sent successfully; otherwise, <c>false</c>.</returns>
        public async Task<bool> SendImagesAsync(IMapping<MediaImagesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new TelegramGrpc.TelegramGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.SendImagesAsync(request: request,
                                                          headers: headers,
                                                          deadline: deadline,
                                                          cancellationToken: cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(TelegramGrpcService),
                                                     path: nameof(SendImagesAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
