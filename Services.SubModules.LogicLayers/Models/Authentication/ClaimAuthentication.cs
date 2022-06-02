using Services.SubModules.LogicLayers.Attributes.Entities;
using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    public enum ClaimAuthentication
    {
        [Claim(ClaimConstant.ID)]
        Id,

        [Claim(ClaimConstant.NAME)]
        Name,

        [Claim(ClaimConstant.EMAIL)]
        Email,

        [Claim(ClaimConstant.ROLE)]
        Role,

        [Claim(ClaimConstant.LANGUAGE)]
        Language,

        [Claim(ClaimConstant.ACCESS_TOKEN)]
        AccessToken
    }
}
