using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IReferralsGrpcService
    {
        Task<bool> CreateReferralAsync(IMapping<CreateReferralReferralsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
