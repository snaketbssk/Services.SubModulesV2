using Google.Protobuf.WellKnownTypes;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface INotificationsGrpcService
    {
        Task<bool> AddSuccessNotificationAsync(IMapping<AddSuccessNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<bool> AddWarningNotificationAsync(IMapping<AddWarningNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<bool> AddErrorNotificationAsync(IMapping<AddErrorNotificationsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
