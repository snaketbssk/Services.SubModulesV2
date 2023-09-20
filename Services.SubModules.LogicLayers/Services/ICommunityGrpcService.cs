using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ICommunityGrpcService
    {
        /// <summary>
        /// Gets currency information asynchronously using gRPC.
        /// </summary>
        /// <param name="mapping">The mapping to the request object.</param>
        /// <param name="cancellationToken">The cancellation token (optional).</param>
        /// <returns>A tuple containing a boolean indicating success and a LabelGrpcModel if successful.</returns>
        Task<(bool isSuccessful, LabelGrpcModel? value)> GetCurrencyAsync(IMapping<IdGrpcModel> mapping, CancellationToken cancellationToken = default);
    }
}
