using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class TokenService : ITokenService
    {
        private readonly ILogger<TokenService> _logger;
        public TokenService(ILogger<TokenService> logger)
        {
            _logger = logger;
        }
        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(TokenConfiguration<TokenRoot>.Instance.Root.SecurityToken);
            var result = new SymmetricSecurityKey(key);
            return result;
        }
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var nowAt = DateTime.UtcNow;
            var symmetricSecurityKey = GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
            var root = TokenConfiguration<TokenRoot>.Instance.Root;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = root.IssuerToken,
                IssuedAt = nowAt,
                Audience = root.AudienceToken,
                Subject = new ClaimsIdentity(claims),
                Expires = nowAt.AddDays(root.DaysExpiresToken),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var result = tokenHandler.WriteToken(token);
            return result;
        }
        public IEnumerable<Claim> DecodeToken(string token)
        {
            var symmetricSecurityKey = GetSymmetricSecurityKey();
            var handler = new JwtSecurityTokenHandler();
            var root = TokenConfiguration<TokenRoot>.Instance.Root;
            handler.ValidateToken(
                token,
                new TokenValidationParameters
                {
                    IssuerSigningKey = symmetricSecurityKey,
                    ValidIssuer = root.IssuerToken,
                    ValidateIssuer = false,
                    ValidAudience = root.AudienceToken,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                },
                out var validateToken);
            var jwtSecurityToken = (JwtSecurityToken)validateToken;
            var result = GetClaims(jwtSecurityToken.Claims);
            return result;
        }
        private IEnumerable<Claim> GetClaims(IEnumerable<Claim> claims)
        {
            var result = new List<Claim>();
            foreach (var claim in claims)
            {
                switch (claim.Type)
                {
                    case JwtClaimConstant.ID:
                        result.Add(new Claim(ClaimConstant.ID, claim.Value));
                        break;
                    case JwtClaimConstant.NAME:
                        result.Add(new Claim(ClaimConstant.NAME, claim.Value));
                        break;
                    case JwtClaimConstant.EMAIL:
                        result.Add(new Claim(ClaimConstant.EMAIL, claim.Value));
                        break;
                    case JwtClaimConstant.ROLE:
                        result.Add(new Claim(ClaimConstant.ROLE, claim.Value));
                        break;
                    case JwtClaimConstant.LANGUAGE:
                        break;
                    case JwtClaimConstant.ACCESS_TOKEN:
                        break;
                    default:
                        result.Add(claim);
                        break;
                }
            }
            return result;
        }
    }
}
