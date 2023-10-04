using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Models.Redis
{
    public interface ISessionRedis : IUserAgentResponse, ICreatedAtRequest
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        DateTime ExpiredAt { get; set; }
    }
}
