using Services.SubModules.LogicLayers.Attributes.Entities;
using Services.SubModules.LogicLayers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    public enum JwtClaimAuthentication
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
