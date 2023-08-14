using Services.SubModules.LogicLayers.Models.Responses;
using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Models.Authentication
{
    /// <summary>
    /// Interface representing user authentication information.
    /// </summary>
    public interface IUserAuthentication : IUserResponse
    {
        /// <summary>
        /// Gets or sets the user's access token.
        /// </summary>
        string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the user's preferred language.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        /// Converts user authentication information to a collection of claims.
        /// </summary>
        /// <returns>A collection of claims representing user authentication information.</returns>
        IEnumerable<Claim> ToClaims();

        /// <summary>
        /// Converts user authentication information to a collection of JWT claims.
        /// </summary>
        /// <returns>A collection of JWT claims representing user authentication information.</returns>
        IEnumerable<Claim> ToJwtClaims();
    }
}
