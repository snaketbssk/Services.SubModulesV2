using Services.SubModules.LogicLayers.Attributes.Entities;
using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    /// <summary>
    /// Enumeration representing various JWT claims associated with user authentication.
    /// </summary>
    public enum IJwtClaimAuthentication
    {
        /// <summary>
        /// User's unique identifier claim for JWT.
        /// </summary>
        [JwtClaim(JwtClaimConstant.ID)]
        Id,

        /// <summary>
        /// User's name claim for JWT.
        /// </summary>
        [JwtClaim(JwtClaimConstant.NAME)]
        Name,

        /// <summary>
        /// User's email claim for JWT.
        /// </summary>
        [JwtClaim(JwtClaimConstant.EMAIL)]
        Email,

        /// <summary>
        /// User's role claim for JWT.
        /// </summary>
        [JwtClaim(JwtClaimConstant.ROLE)]
        Role,

        /// <summary>
        /// User's language claim for JWT.
        /// </summary>
        [JwtClaim(JwtClaimConstant.LANGUAGE)]
        Language,

        /// <summary>
        /// User's access token claim for JWT.
        /// </summary>
        [JwtClaim(JwtClaimConstant.ACCESS_TOKEN)]
        AccessToken
    }
}
