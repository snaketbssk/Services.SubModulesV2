using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing user agent information.
    /// </summary>
    public interface IUserAgentService
    {
        /// <summary>
        /// Gets the user agent information for the current request.
        /// </summary>
        /// <returns>An instance of IUserAgentResponse containing user agent details.</returns>
        IUserAgentResponse GetUserAgent();
    }
}
