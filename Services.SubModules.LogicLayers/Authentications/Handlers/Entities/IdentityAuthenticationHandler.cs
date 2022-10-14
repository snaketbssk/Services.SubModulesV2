using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.SubModules.LogicLayers.Authentications.SchemeOptions.Entities;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Linq;
using Services.SubModules.LogicLayers.Models.Mappings.Entities;

namespace Services.SubModules.LogicLayers.Authentications.Handlers.Entities
{
    public class IdentityAuthenticationHandler : BaseAuthenticationHandler<IdentityAuthenticationSchemeOptions>
    {
        private readonly ITokenService _tokenService;
        private readonly IIdentityGrpcService _identityGrpcService;
        public IdentityAuthenticationHandler(
            IIdentityGrpcService identityGrpcService,
            ITokenService tokenService,
            IOptionsMonitor<IdentityAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _tokenService = tokenService;
            _identityGrpcService = identityGrpcService;
        }

        protected override async Task<IEnumerable<Claim>> GetClaimsAsync(string token)
        {
            var claims = _tokenService.DecodeToken(token);

            var idUserTable = claims.FirstOrDefault(x => x.Type == ClaimConstant.ID);
            var userIdentityGrpcRequestMapping = new UserIdentityGrpcRequestMapping(Guid.Parse(idUserTable.Value));
            var result = await _identityGrpcService.ExecuteAsync(userIdentityGrpcRequestMapping);

            return result.Claims.Select(x => new Claim(x.Type, x.Value));
        }
    }
}
