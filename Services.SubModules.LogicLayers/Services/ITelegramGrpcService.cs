using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ITelegramGrpcService
    {
        Task<bool> SendMessageAsync(IMapping<MessageTelegramGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<bool> SendMediaAsync(IMapping<MediaFilesGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<bool> SendImagesAsync(IMapping<MediaImagesGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
