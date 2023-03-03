using Services.SubModules.LogicLayers.Attributes.Entities;
using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    public enum IJwtClaimAuthentication
    {
        [JwtClaim(JwtClaimConstant.ID)]
        Id,

        [JwtClaim(JwtClaimConstant.NAME)]
        Name,

        [JwtClaim(JwtClaimConstant.EMAIL)]
        Email,

        [JwtClaim(JwtClaimConstant.ROLE)]
        Role,

        [JwtClaim(JwtClaimConstant.LANGUAGE)]
        Language,

        [JwtClaim(JwtClaimConstant.ACCESS_TOKEN)]
        AccessToken
    }
}
