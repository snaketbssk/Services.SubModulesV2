using Services.SubModules.LogicLayers.Models.Responses;
using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    public interface IUserAuthentication : IUserResponse
    {
        string AccessToken { get; set; }
        string Language { get; set; }

        IEnumerable<Claim> ToClaims();
        IEnumerable<Claim> ToJwtClaims();
    }
}
