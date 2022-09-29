using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface INotificationsGrpcService
    {
        Task<EmptyNotificationsGrpcResponse> ExecuteAsync(IMapping<AddSuccessNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<EmptyNotificationsGrpcResponse> ExecuteAsync(IMapping<AddWarningNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<EmptyNotificationsGrpcResponse> ExecuteAsync(IMapping<AddErrorNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
