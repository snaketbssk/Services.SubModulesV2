using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request that encapsulates an instance of HttpContext.
    /// </summary>
    public class HttpContextRequest : IHttpContextRequest
    {
        /// <summary>
        /// Gets or sets the HttpContext instance.
        /// </summary>
        public HttpContext HttpContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpContextRequest"/> class.
        /// </summary>
        public HttpContextRequest()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpContextRequest"/> class with the provided HttpContext.
        /// </summary>
        /// <param name="httpContext">The HttpContext instance.</param>
        public HttpContextRequest(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }
    }
}
