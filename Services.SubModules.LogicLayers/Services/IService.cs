using Microsoft.AspNetCore.Http;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IService
    {
        HttpContext HttpContext { get; }
        HttpResponse HttpResponse { get; }
        HttpRequest HttpRequest { get; }
    }
}
