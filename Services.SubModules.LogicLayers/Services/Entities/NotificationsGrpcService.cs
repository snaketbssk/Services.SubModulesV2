using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        public NotificationsGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().NOTIFICATIONS_HOST, tokenService)
        {
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Adds a user notification via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping object to create the request.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Returns true if the notification was added successfully, otherwise false.</returns>
        public async Task<bool> AddUserNotification(IMapping<CreateUserNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                // Create a gRPC client
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);

                // Map the request using the provided mapping
                var request = mapping.Map();

                // Get headers and deadline for the gRPC call
                var headers = GetHeaders();
                var deadline = GetDeadline();

                // Call the gRPC method to add a user notification
                await client.AddUserNotificationAsync(request: request,
                                                      headers: headers,
                                                      deadline: deadline,
                                                      cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                // Handle and log exceptions using the exception service
                await _exceptionService.ExecuteAsync(method: nameof(NotificationsGrpcService),
                                                     path: nameof(AddUserNotification),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        /// <summary>
        /// Adds a group notification via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping object to create the request.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Returns true if the notification was added successfully, otherwise false.</returns>
        public async Task<bool> AddGroupNotification(IMapping<CreateGroupNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                // Create a gRPC client
                var client = new NotificationsGrpc.NotificationsGrpcClient(GrpcChannel);

                // Map the request using the provided mapping
                var request = mapping.Map();

                // Get headers and deadline for the gRPC call
                var headers = GetHeaders();
                var deadline = GetDeadline();

                // Call the gRPC method to add a group notification
                await client.AddGroupNotificationAsync(request: request,
                                                       headers: headers,
                                                       deadline: deadline,
                                                       cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                // Handle and log exceptions using the exception service
                await _exceptionService.ExecuteAsync(method: nameof(NotificationsGrpcService),
                                                     path: nameof(AddGroupNotification),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}
