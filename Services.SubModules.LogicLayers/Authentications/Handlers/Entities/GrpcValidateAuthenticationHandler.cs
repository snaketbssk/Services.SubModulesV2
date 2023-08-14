using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.SubModules.LogicLayers.Authentications.SchemeOptions.Entities;
using Services.SubModules.LogicLayers.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Services.SubModules.LogicLayers.Authentications.Handlers.Entities
{
    /// <summary>
    /// Authentication handler for validating gRPC requests using a custom authentication scheme.
    /// </summary>
    public class GrpcValidateAuthenticationHandler : BaseAuthenticationHandler<GrpcValidateAuthenticationSchemeOptions>
    {
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GrpcValidateAuthenticationHandler"/> class.
        /// </summary>
        /// <param name="tokenService">The token service used to decode and validate tokens.</param>
        /// <param name="options">The options for the authentication scheme.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="encoder">The URL encoder.</param>
        /// <param name="clock">The system clock.</param>
        public GrpcValidateAuthenticationHandler(ITokenService tokenService,
                                                 IOptionsMonitor<GrpcValidateAuthenticationSchemeOptions> options,
                                                 ILoggerFactory logger,
                                                 UrlEncoder encoder,
                                                 ISystemClock clock)
                                                 : base(options, logger, encoder, clock)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Retrieves and validates claims from the provided token.
        /// </summary>
        /// <param name="token">The token extracted from the request.</param>
        /// <returns>A collection of claims representing the authenticated user.</returns>
        protected override Task<IEnumerable<Claim>> GetClaimsAsync(string token)
        {
            var result = _tokenService.DecodeToken(token);
            return Task.FromResult(result);
        }
    }
}
