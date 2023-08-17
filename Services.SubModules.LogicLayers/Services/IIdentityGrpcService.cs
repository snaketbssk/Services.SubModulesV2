using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;
using System.Threading;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing identity-related gRPC operations.
    /// </summary>
    public interface IIdentityGrpcService
    {
        /// <summary>
        /// Gets a user identity using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the identifier of the user.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the retrieved UserIdentityGrpcResponse.</returns>
        Task<(bool isSuccessful, UserIdentityGrpcResponse?)> GetUserAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds roles to a user's identity using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the user identifier and roles to add.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if successful; otherwise, false.</returns>
        Task<bool> AddRolesToUserAsync(IMapping<AddRolesUserIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs authentication using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing authentication information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. A tuple indicating success and the retrieved UserIdentityGrpcResponse.</returns>
        Task<(bool isSuccessful, UserIdentityGrpcResponse?)> AuthenticationAsync(IMapping<AuthenticationIdentityGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
