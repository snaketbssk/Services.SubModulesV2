using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a base service with access to HTTP context and related objects.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Gets the HTTP context associated with the service.
        /// </summary>
        HttpContext HttpContext { get; }

        /// <summary>
        /// Gets the HTTP response associated with the service.
        /// </summary>
        HttpResponse HttpResponse { get; }

        /// <summary>
        /// Gets the HTTP request associated with the service.
        /// </summary>
        HttpRequest HttpRequest { get; }
    }
}
