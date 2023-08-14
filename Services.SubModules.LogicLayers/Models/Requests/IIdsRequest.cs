using Services.SubModules.LogicLayers.Models.Requests.Entities;

namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for requests containing a list of ID requests.
    /// </summary>
    public interface IIdsRequest
    {
        /// <summary>
        /// Gets or sets the list of ID requests.
        /// </summary>
        List<IdRequest> Ids { get; set; }
    }
}
