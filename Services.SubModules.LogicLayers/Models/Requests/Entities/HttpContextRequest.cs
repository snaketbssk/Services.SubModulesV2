using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class HttpContextRequest : IHttpContextRequest
    {
        public HttpContext HttpContext { get; set; }

        public HttpContextRequest()
        {

        }
        public HttpContextRequest(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }
    }
}
