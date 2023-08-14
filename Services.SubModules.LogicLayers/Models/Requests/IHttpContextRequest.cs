using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for request classes that require access to the current HttpContext.
    /// </summary>
    public interface IHttpContextRequest
    {
        /// <summary>
        /// Gets or sets the current HttpContext.
        /// </summary>
        HttpContext HttpContext { get; set; }
    }
}
