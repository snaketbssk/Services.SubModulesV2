using Services.SubModules.LogicLayers.Models.Responses;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IEnumService
    {
        IEnumerable<IEnumResponse> Get<TEnum>() where TEnum : Enum;
    }
}
