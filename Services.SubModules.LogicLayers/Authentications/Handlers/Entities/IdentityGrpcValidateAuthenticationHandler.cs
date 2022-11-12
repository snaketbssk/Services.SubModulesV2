using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.SubModules.LogicLayers.Authentications.SchemeOptions.Entities;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Authentication.Entities;
using Services.SubModules.LogicLayers.Models.Mappings.Entities;
using Services.SubModules.LogicLayers.Models.Redis.Entities;
using Services.SubModules.LogicLayers.Services;
using StackExchange.Redis;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Authentications.Handlers.Entities
{
    public class IdentityGrpcValidateAuthenticationHandler : BaseAuthenticationHandler<IdentityGrpcValidateAuthenticationSchemeOptions>
    {
        private readonly IIdentityGrpcService _identityGrpcService;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly ITokenService _tokenService;

        public IdentityGrpcValidateAuthenticationHandler(
                                                         IIdentityGrpcService identityGrpcService,
                                                         IOptionsMonitor<IdentityGrpcValidateAuthenticationSchemeOptions> options,
                                                         ILoggerFactory logger,
                                                         UrlEncoder encoder,
                                                         ISystemClock clock,
                                                         IConnectionMultiplexer connectionMultiplexer,
                                                         ITokenService tokenService)
            : base(options, logger, encoder, clock)
        {
            _identityGrpcService = identityGrpcService;
            _connectionMultiplexer = connectionMultiplexer;
            _tokenService = tokenService;
        }

        protected override async Task<IEnumerable<Claim>> GetClaimsAsync(string token)
        {
            var result = new List<Claim>();
            var decodeClaims = _tokenService.DecodeToken(token);
            var idUserTable = decodeClaims.FirstOrDefault(x => x.Type == ClaimConstant.ID);
            var keyRedis = $"{nameof(UserRedis)}={idUserTable.Value}";
            var database = _connectionMultiplexer.GetDatabase();
            var userIdentityGrpcResponse = await database.StringGetAsync(keyRedis);

            if (userIdentityGrpcResponse.HasValue)
            {
                var userRedis = JsonSerializer.Deserialize<UserRedis>(userIdentityGrpcResponse.ToString());
                var userAuthentication = new UserAuthentication(
                    id: userRedis.Id,
                    name: userRedis.Name,
                    email: userRedis.Email,
                    roles: new List<string>(),
                    accessToken: token,
                    language: "ru");
                result.AddRange(userAuthentication.ToClaims());
                result.AddRange(userRedis.Claims.Select(x => new Claim(x.Type, x.Value)));
            }
            else
            {
                var authenticationIdentityGrpcRequestMapping = new AuthenticationIdentityGrpcRequestMapping(token);
                var response = await _identityGrpcService.ExecuteAsync(authenticationIdentityGrpcRequestMapping);

                var userAuthentication = new UserAuthentication(
                    id: Guid.Parse(response.Id),
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
