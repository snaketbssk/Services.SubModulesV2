using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;
using System.Threading;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing notification-related gRPC operations.
    /// </summary>
    public interface INotificationsGrpcService
    {
        /// <summary>
        /// Adds a success notification using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the success notification information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the notification was added successfully; otherwise, false.</returns>
        Task<bool> AddSuccessNotificationAsync(IMapping<AddSuccessNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a warning notification using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the warning notification information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the notification was added successfully; otherwise, false.</returns>
        Task<bool> AddWarningNotificationAsync(IMapping<AddWarningNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds an error notification using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the error notification information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the notification was added successfully; otherwise, false.</returns>
        Task<bool> AddErrorNotificationAsync(IMapping<AddErrorNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
