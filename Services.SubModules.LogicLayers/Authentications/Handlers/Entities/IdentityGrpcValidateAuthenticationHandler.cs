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
    public class IdentityGrpcValidateAuthenticationHandler : BaseAuthenticationHandler<IdentityGrpcValidateAuthenticationSchemeOptions>
    {
        private readonly IIdentityGrpcService _identityGrpcService;
        private readonly IIdentityCacheService _identityCacheService;
        private readonly ITokenService _tokenService;

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

        protected override async Task<IEnumerable<Claim>> GetClaimsAsync(string token)
        {
            var result = new List<Claim>();
            var decodeClaims = _tokenService.DecodeToken(token);
            var idUserTable = decodeClaims.FirstOrDefault(x => x.Type == ClaimConstant.ID);
            var (cacheIsSuccessful, value) = await _identityCacheService.User.TryGetAsync(idUserTable.Value);
            if (cacheIsSuccessful)
            {
                var userAuthentication = new UserAuthentication(
                    id: value.Id,
                    name: value.Name,
                    email: value.Email,
                    roles: new List<string>(),
                    accessToken: token,
                    language: "ru");
                result.AddRange(userAuthentication.ToClaims());
                result.AddRange(value.Claims.Select(x => new Claim(x.Type, x.Value)));
            }
            else
            {
                var authenticationIdentityGrpcRequestMapping = new AuthenticationIdentityGrpcRequestMapping(token);
                var (grpcIsSuccessful, response) = await _identityGrpcService.AuthenticationAsync(authenticationIdentityGrpcRequestMapping);

                if (!grpcIsSuccessful)
                    throw new ArgumentException(nameof(grpcIsSuccessful));
                ArgumentNullException.ThrowIfNull(response, nameof(response));

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
