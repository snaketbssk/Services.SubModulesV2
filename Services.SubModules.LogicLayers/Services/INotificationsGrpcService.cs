using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service interface for interacting with notifications via gRPC.
    /// </summary>
    public interface INotificationsGrpcService
    {
        /// <summary>
        /// Adds a group notification via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping object to create the request.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Returns true if the notification was added successfully, otherwise false.</returns>
        Task<bool> AddGroupNotification(IMapping<CreateGroupNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a user notification via gRPC.
        /// </summary>
        /// <param name="mapping">The mapping object to create the request.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>Returns true if the notification was added successfully, otherwise false.</returns>
        Task<bool> AddUserNotification(IMapping<CreateUserNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
