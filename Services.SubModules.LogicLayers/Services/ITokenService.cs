using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing token-related operations.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Decodes the specified token and retrieves the claims.
        /// </summary>
        /// <param name="token">The token to decode.</param>
        /// <returns>An enumerable collection of claims extracted from the token.</returns>
        IEnumerable<Claim> DecodeToken(string token);

        /// <summary>
        /// Generates a token based on the provided claims.
        /// </summary>
        /// <param name="claims">The claims to include in the token.</param>
        /// <returns>The generated token as a string.</returns>
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
