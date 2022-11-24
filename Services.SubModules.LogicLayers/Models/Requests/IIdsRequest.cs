using Services.SubModules.LogicLayers.Models.Requests.Entities;

namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IIdsRequest
    {
        List<IdRequest> Ids { get; set; }
    }
}
