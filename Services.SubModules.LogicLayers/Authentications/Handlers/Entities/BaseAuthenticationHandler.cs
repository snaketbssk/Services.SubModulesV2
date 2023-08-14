using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.SubModules.LogicLayers.Constants;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Services.SubModules.LogicLayers.Authentications.Handlers.Entities
{
    /// <summary>
    /// Base class for authentication handlers. Provides common functionality for handling authentication using JWT tokens.
    /// </summary>
    /// <typeparam name="TOptions">The type of authentication scheme options.</typeparam>
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

        /// <summary>
        /// Checks if the request contains the required authorization header.
        /// </summary>
        /// <returns><c>true</c> if the header is present; otherwise, <c>false</c>.</returns>
        private bool HasHeader()
        {
            var result = Request.Headers.ContainsKey(HeaderConstant.AUTHORIZATION);
            return result;
        }

        /// <summary>
        /// Retrieves the authorization header value from the request.
        /// </summary>
        /// <returns>The token value extracted from the header.</returns>
        private string GetHeader()
        {
            var authorizationHeader = Request.Headers[HeaderConstant.AUTHORIZATION].ToString();

            if (!authorizationHeader.Contains(JwtBearerDefaults.AuthenticationScheme))
                throw new ArgumentNullException(nameof(authorizationHeader));

            var result = authorizationHeader.Split(" ").Last();

            return result;
        }

        /// <summary>
        /// Handles the authentication process.
        /// </summary>
        /// <returns>An <see cref="AuthenticateResult"/> indicating the authentication result.</returns>
        protected sealed override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!HasHeader())
                return await Task.FromResult(AuthenticateResult.NoResult());

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

        /// <summary>
        /// Retrieves and validates claims from the token.
        /// </summary>
        /// <param name="token">The token extracted from the authorization header.</param>
        /// <returns>A collection of claims representing the authenticated user.</returns>
        protected abstract Task<IEnumerable<Claim>> GetClaimsAsync(string token);
    }
}
