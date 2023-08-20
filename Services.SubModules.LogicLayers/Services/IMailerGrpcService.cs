using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing mailer-related gRPC operations.
    /// </summary>
    public interface IMailerGrpcService
    {
        /// <summary>
        /// Sends a message using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the message information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the message was sent successfully; otherwise, false.</returns>
        Task<bool> SendMessageAsync(IMapping<MessageMailerGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
