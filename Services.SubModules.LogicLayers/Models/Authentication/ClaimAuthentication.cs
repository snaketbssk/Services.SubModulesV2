using Services.SubModules.LogicLayers.Attributes.Entities;
using Services.SubModules.LogicLayers.Constants;
using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    /// <summary>
    /// Enumeration representing various claims associated with user authentication.
    /// </summary>
    public enum ClaimAuthentication
    {
        /// <summary>
        /// User's unique identifier claim.
        /// </summary>
        [Claim(ClaimConstant.ID)]
        Id,

        /// <summary>
        /// User's name claim.
        /// </summary>
        [Claim(ClaimConstant.NAME)]
        Name,

        /// <summary>
        /// User's email claim.
        /// </summary>
        [Claim(ClaimConstant.EMAIL)]
        Email,

        /// <summary>
        /// User's role claim.
        /// </summary>
        [Claim(ClaimConstant.ROLE)]
        Role,

        /// <summary>
        /// User's language claim.
        /// </summary>
        [Claim(ClaimConstant.LANGUAGE)]
        Language,

        /// <summary>
        /// User's access token claim.
        /// </summary>
        [Claim(ClaimConstant.ACCESS_TOKEN)]
        AccessToken
    }
}
