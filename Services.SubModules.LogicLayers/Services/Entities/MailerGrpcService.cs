using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Provides functionality for sending messages via gRPC using the Mailer service.
    /// Implements the IMailerGrpcService interface.
    /// </summary>
    public class MailerGrpcService : GrpcService, IMailerGrpcService
    {
        /// <summary>
        /// Logger instance for logging within the MailerGrpcService class.
        /// </summary>
        private readonly ILogger<MailerGrpcService> _logger;

        /// <summary>
        /// Exception service for handling and logging exceptions.
        /// </summary>
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the MailerGrpcService class.
        /// </summary>
        /// <param name="exceptionService">The exception service for handling exceptions.</param>
        /// <param name="tokenService">The token service for managing authentication tokens.</param>
        /// <param name="logger">The logger instance for logging.</param>
        public MailerGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<MailerGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().MAILER_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Sends a message asynchronously via gRPC using the Mailer service.
        /// </summary>
        /// <param name="mapping">The mapping containing the message data to be sent.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>True if the message was sent successfully, false otherwise.</returns>
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
                await _exceptionService.ExecuteAsync(method: nameof(MailerGrpcService),
                                                     path: nameof(SendMessageAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
