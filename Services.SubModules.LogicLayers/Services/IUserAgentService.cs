using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IUserAgentService
    {
        IUserAgentResponse GetUserAgent();
    }
}
