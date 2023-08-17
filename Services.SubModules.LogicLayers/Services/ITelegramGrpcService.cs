using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;
using System.Threading;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing Telegram-related gRPC operations.
    /// </summary>
    public interface ITelegramGrpcService
    {
        /// <summary>
        /// Sends a text message using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the message information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the message was sent successfully; otherwise, false.</returns>
        Task<bool> SendMessageAsync(IMapping<MessageTelegramGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends media files using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the media files information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the media files were sent successfully; otherwise, false.</returns>
        Task<bool> SendMediaAsync(IMapping<MediaFilesGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends images using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the images information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the images were sent successfully; otherwise, false.</returns>
        Task<bool> SendImagesAsync(IMapping<MediaImagesGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
