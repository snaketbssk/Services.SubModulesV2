using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.SubModules.LogicLayers.Authentications.SchemeOptions.Entities;
using Services.SubModules.LogicLayers.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Authentications.Handlers.Entities
{
    public class GrpcValidateAuthenticationHandler : BaseAuthenticationHandler<GrpcValidateAuthenticationSchemeOptions>
    {
        private readonly ITokenService _tokenService;

        public GrpcValidateAuthenticationHandler(ITokenService tokenService,
                                                 IOptionsMonitor<GrpcValidateAuthenticationSchemeOptions> options,
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
