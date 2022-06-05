using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ITelegramGrpcService
    {
        Task<MessageTelegramGrpcResponse> ExecuteAsync(IMapping<MessageTelegramGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
