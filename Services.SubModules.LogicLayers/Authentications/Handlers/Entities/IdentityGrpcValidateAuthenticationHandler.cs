using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.SubModules.LogicLayers.Authentications.SchemeOptions.Entities;
using Services.SubModules.LogicLayers.Models.Authentication.Entities;
using Services.SubModules.LogicLayers.Models.Mappings.Entities;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using Services.SubModules.LogicLayers.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Services.SubModules.LogicLayers.Authentications.Handlers.Entities
{
    public class IdentityGrpcValidateAuthenticationHandler : BaseAuthenticationHandler<IdentityGrpcValidateAuthenticationSchemeOptions>
    {
        private readonly IIdentityGrpcService _identityGrpcService;
        public IdentityGrpcValidateAuthenticationHandler(
            IIdentityGrpcService identityGrpcService,
            IOptionsMonitor<IdentityGrpcValidateAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _identityGrpcService = identityGrpcService;
        }

        protected override async Task<IEnumerable<Claim>> GetClaimsAsync(string token)
        {
            var authenticationIdentityGrpcRequestMapping = new AuthenticationIdentityGrpcRequestMapping(token);
            var response = await _identityGrpcService.ExecuteAsync(authenticationIdentityGrpcRequestMapping);

            var result = new List<Claim>();
            var userAuthentication = new UserAuthentication(
                id: new Guid(response.Id.ToByteArray()),
                name: response.Login,
                email: response.Email,
                roles: new List<string>(),
                accessToken: token,
                language: "ru");
            result.AddRange(userAuthentication.ToClaims());
            result.AddRange(response.Claims.Select(x => new Claim(x.Type, x.Value)));

            return result;
        }
    }
}
