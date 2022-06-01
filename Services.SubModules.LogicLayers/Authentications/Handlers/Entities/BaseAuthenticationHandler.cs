using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.SubModules.LogicLayers.Constants;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Services.SubModules.LogicLayers.Authentications.Handlers.Entities
{
    public abstract class BaseAuthenticationHandler<TOptions> : AuthenticationHandler<TOptions>
        where TOptions : AuthenticationSchemeOptions, new()
    {
        public BaseAuthenticationHandler(
            IOptionsMonitor<TOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }
        private bool HasHeader()
        {
            var result = Request.Headers.ContainsKey(HeaderConstant.AUTHORIZATION);
            return result;
        }
        private string GetHeader()
        {
            var result = Request.Headers[HeaderConstant.AUTHORIZATION].ToString();
            return result;
        }
        protected sealed override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!HasHeader())
            {
                return await Task.FromResult(AuthenticateResult.Fail($"{DateTime.UtcNow} Header not found."));
            }
            IEnumerable<Claim> claims;
            try
            {
                var tokenHeader = GetHeader();
                claims = await GetClaimsAsync(tokenHeader);
            }
            catch (Exception)
            {
                return await Task.FromResult(AuthenticateResult.Fail($"{DateTime.UtcNow} Token parse exception"));
            }
            var claimsIdentity = new ClaimsIdentity(claims, nameof(BaseAuthenticationHandler<TOptions>));
            var authenticationTicket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);
            return await Task.FromResult(AuthenticateResult.Success(authenticationTicket));
        }
        protected abstract Task<IEnumerable<Claim>> GetClaimsAsync(string token);
    }
}
