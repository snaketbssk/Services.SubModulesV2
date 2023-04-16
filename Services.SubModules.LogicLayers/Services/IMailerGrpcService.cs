using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IMailerGrpcService
    {
        Task<bool> SendMessageAsync(IMapping<MessageMailerGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
