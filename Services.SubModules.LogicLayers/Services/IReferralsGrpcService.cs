using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing referral-related gRPC operations.
    /// </summary>
    public interface IReferralsGrpcService
    {
        /// <summary>
        /// Creates a referral using the specified mapping.
        /// </summary>
        /// <param name="mapping">The mapping containing the referral information.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the referral was created successfully; otherwise, false.</returns>
        Task<bool> CreateReferralAsync(IMapping<CreateReferralReferralsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
