using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IIdentityGrpcService
    {
        Task<UserIdentityGrpcResponse> ExecuteAsync(IMapping<UserIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<EmptyIdentityGrpcResponse> ExecuteAsync(IMapping<AddRolesUserIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
