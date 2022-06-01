using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Services
{
    public interface ITokenService
    {
        IEnumerable<Claim> DecodeToken(string token);
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
