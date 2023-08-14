using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.SubModules.LogicLayers.Authentications.SchemeOptions.Entities;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Authentication.Entities;
using Services.SubModules.LogicLayers.Models.Mappings.Entities;
using Services.SubModules.LogicLayers.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Services.SubModules.LogicLayers.Authentications.Handlers.Entities
{
    /// <summary>
    /// Authentication handler for validating gRPC requests using Identity authentication scheme.
    /// </summary>
    public class IdentityGrpcValidateAuthenticationHandler : BaseAuthenticationHandler<IdentityGrpcValidateAuthenticationSchemeOptions>
    {
        private readonly IIdentityGrpcService _identityGrpcService;
        private readonly IIdentityCacheService _identityCacheService;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityGrpcValidateAuthenticationHandler"/> class.
        /// </summary>
        /// <param name="identityGrpcService">The gRPC service for identity-related operations.</param>
        /// <param name="options">The options for the authentication scheme.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="encoder">The URL encoder.</param>
        /// <param name="clock">The system clock.</param>
        /// <param name="tokenService">The service for decoding and validating tokens.</param>
        /// <param name="identityCacheService">The service for caching identity-related data.</param>
        public IdentityGrpcValidateAuthenticationHandler(IIdentityGrpcService identityGrpcService,
                                                         IOptionsMonitor<IdentityGrpcValidateAuthenticationSchemeOptions> options,
                                                         ILoggerFactory logger,
                                                         UrlEncoder encoder,
                                                         ISystemClock clock,
                                                         ITokenService tokenService,
                                                         IIdentityCacheService identityCacheService)
            : base(options, logger, encoder, clock)
        {
            _identityGrpcService = identityGrpcService;
            _tokenService = tokenService;
            _identityCacheService = identityCacheService;
        }

        /// <summary>
        /// Retrieves and validates claims from the provided token.
        /// </summary>
        /// <param name="token">The token extracted from the request.</param>
        /// <returns>A collection of claims representing the authenticated user.</returns>
        protected override async Task<IEnumerable<Claim>> GetClaimsAsync(string token)
        {
            var result = new List<Claim>();
            var decodeClaims = _tokenService.DecodeToken(token);
            var idUserTable = decodeClaims.FirstOrDefault(x => x.Type == ClaimConstant.ID);

            ArgumentNullException.ThrowIfNull(idUserTable, nameof(idUserTable));

            var (cacheSessionIsSuccessful, sessionValue) = await _identityCacheService.Sessions.TryGetAsync(token);

            if (!cacheSessionIsSuccessful)
                throw new ArgumentException(nameof(cacheSessionIsSuccessful));
            if (idUserTable.Value != sessionValue)
                throw new ArgumentException(nameof(sessionValue));

            var (cacheUserIsSuccessful, userValue) = await _identityCacheService.Users.TryGetAsync(idUserTable.Value);
            if (cacheUserIsSuccessful)
            {
                // Construct claims for a cached user
                var userAuthentication = new UserAuthentication(
                    id: userValue.Id,
                    name: userValue.Name,
                    email: userValue.Email,
                    roles: new List<string>(),
                    accessToken: token,
                    language: "ru");
                result.AddRange(userAuthentication.ToClaims());
                result.AddRange(userValue.Claims.Select(x => new Claim(x.Type, x.Value)));
            }
            else
            {
                // Fetch user details via gRPC if not found in cache
                var authenticationIdentityGrpcRequestMapping = new AuthenticationIdentityGrpcRequestMapping(token);
                var (grpcIsSuccessful, response) = await _identityGrpcService.AuthenticationAsync(authenticationIdentityGrpcRequestMapping);

                if (!grpcIsSuccessful)
                    throw new ArgumentException(nameof(grpcIsSuccessful));
                ArgumentNullException.ThrowIfNull(response, nameof(response));

                // Construct claims for a user fetched via gRPC
                var userAuthentication = new UserAuthentication(id: Guid.Parse(response.Id),
                                                                name: response.Login,
                                                                email: response.Email,
                                                                roles: new List<string>(),
                                                                accessToken: token,
                                                                language: "ru");
                result.AddRange(userAuthentication.ToClaims());
                result.AddRange(response.Claims.Select(x => new Claim(x.Type, x.Value)));
            }

            return result;
        }
    }
}
