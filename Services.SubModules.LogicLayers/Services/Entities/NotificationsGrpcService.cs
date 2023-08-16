using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Provides functionality for interacting with notifications via gRPC.
    /// Implements the INotificationsGrpcService interface.
    /// </summary>
    public class NotificationsGrpcService : GrpcService, INotificationsGrpcService
    {
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the NotificationsGrpcService class.
        /// </summary>
        /// <param name="exceptionService">The exception service for handling exceptions.</param>
        /// <param name="tokenService">The token service for managing authentication tokens.</param>
        public NotificationsGrpcService(IExceptionService exceptionService,
                                        ITokenService tokenService)
                                        : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().NOTIFICATIONS_HOST, tokenService)
        {
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Adds a success notification asynchronously via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping containing the success notification data.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>True if the notification was added successfully, false otherwise.</returns>
        public async Task<bool> AddSuccessNotificationAsync(IMapping<AddSuccessNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.AddSuccessNotificationAsync(request: request,
                                                                      headers: headers,
                                                                      deadline: deadline,
                                                                      cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(NotificationsGrpcService),
                                                     path: nameof(AddSuccessNotificationAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        /// <summary>
        /// Adds a warning notification asynchronously via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping containing the warning notification data.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>True if the notification was added successfully, false otherwise.</returns>

        public async Task<bool> AddWarningNotificationAsync(IMapping<AddWarningNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.AddWarningNotificationAsync(request: request,
                                                                      headers: headers,
                                                                      deadline: deadline,
                                                                      cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(NotificationsGrpcService),
                                                     path: nameof(AddWarningNotificationAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        /// <summary>
        /// Adds an error notification asynchronously via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping containing the error notification data.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>True if the notification was added successfully, false otherwise.</returns>
        public async Task<bool> AddErrorNotificationAsync(IMapping<AddErrorNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.AddErrorNotificationAsync(request: request,
                                                                    headers: headers,
                                                                    deadline: deadline,
                                                                    cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(NotificationsGrpcService),
                                                     path: nameof(AddErrorNotificationAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
