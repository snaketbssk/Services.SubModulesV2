using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IHttpContextRequest
    {
        HttpContext HttpContext { get; set; }
    }
}
