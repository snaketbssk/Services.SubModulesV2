using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class EnumService : IEnumService
    {
        public IEnumerable<IEnumResponse> Get<TEnum>() where TEnum : Enum
        {
            var result = new List<IEnumResponse>();
            result.AddRange(Enum.GetValues(typeof(CommonEnumResponse))
                                .Cast<CommonEnumResponse>()
                                .Select(value => EnumResponse.FromEnum(value)));
            result.AddRange(Enum.GetValues(typeof(TEnum))
                                .Cast<TEnum>()
                                .Select(value => EnumResponse.FromEnum(value)));

            return result;
        }
    }
}
