using System.Security.Claims;
using Services.SubModules.LogicLayers.Models.Responses;

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
