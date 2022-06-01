using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.SubModules.LogicLayers.Authentications.SchemeOptions.Entities;
using Services.SubModules.LogicLayers.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Services.SubModules.LogicLayers.Authentications.Handlers.Entities
{
    public class IdentityAuthenticationHandler : BaseAuthenticationHandler<IdentityAuthenticationSchemeOptions>
    {
        private readonly ITokenService _tokenService;
        public IdentityAuthenticationHandler(
            ITokenService tokenService,
            IOptionsMonitor<IdentityAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _tokenService = tokenService;
        }

        protected override Task<IEnumerable<Claim>> GetClaimsAsync(string token)
        {
            var result = _tokenService.DecodeToken(token);
            return Task.FromResult(result);
        }
    }
}
