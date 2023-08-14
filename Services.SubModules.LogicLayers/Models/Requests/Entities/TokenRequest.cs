using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request for a token.
    /// </summary>
    public class TokenRequest : ITokenRequest
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        [StringLength(1024)]
        public string? Token { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRequest"/> class.
        /// </summary>
        public TokenRequest()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRequest"/> class with a token.
        /// </summary>
        /// <param name="token">The token.</param>
        public TokenRequest(string token)
        {
            Token = token;
        }
    }
}
