using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IReferralsGrpcService
    {
        Task<bool> CreateReferralAsync(IMapping<CreateReferralReferralsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}
