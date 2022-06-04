using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    public interface IUserAuthentication
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        List<string> Roles { get; set; }
        string AccessToken { get; set; }
        string Language { get; set; }

        IEnumerable<Claim> ToClaims();
        IEnumerable<Claim> ToJwtClaims();
    }
}
