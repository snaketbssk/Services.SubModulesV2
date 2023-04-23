using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IIdentityGrpcService
    {
        Task<(bool isSuccessful, UserIdentityGrpcResponse?)> GetUserAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default);
        Task<bool> AddRolesToUserAsync(IMapping<AddRolesUserIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, UserIdentityGrpcResponse?)> AuthenticationAsync(IMapping<AuthenticationIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
