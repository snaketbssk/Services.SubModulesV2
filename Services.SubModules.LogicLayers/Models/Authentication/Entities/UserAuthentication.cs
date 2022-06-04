using Services.SubModules.LogicLayers.Attributes.Entities;
using Services.SubModules.LogicLayers.Extensions;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Models.Authentication.Entities
{
    public class UserAuthentication : UserResponse, IUserAuthentication
    {
        public string AccessToken { get; set; }
        public string Language { get; set; }
        public UserAuthentication(
            Guid id,
            string name,
            string email,
            IEnumerable<string> roles,
            string accessToken,
            string language)
        {
            Id = id;
            Name = name;
            Email = email;
            Roles = roles.ToList();
            AccessToken = accessToken;
            Language = language;
        }
        public UserAuthentication(ClaimsPrincipal claimsPrincipal)
        {
            foreach (ClaimAuthentication claimUser in Enum.GetValues(typeof(ClaimAuthentication)))
            {
                var claimAttribute = claimUser.GetAttribute<ClaimAttribute>();
                var claims = claimsPrincipal.FindAll(claimAttribute.Name) ?? throw new ArgumentNullException(nameof(claimUser));
                switch (claimUser)
                {
                    case ClaimAuthentication.Id: Id = Guid.Parse(claims.First().Value); break;
                    case ClaimAuthentication.Name: Name = claims.First().Value; break;
                    case ClaimAuthentication.Email: Email = claims.First().Value; break;
                    case ClaimAuthentication.Role: Roles = claims.Select(v => v.Value).ToList(); break;
                    case ClaimAuthentication.Language: break;
                    case ClaimAuthentication.AccessToken: break;
                    default: throw new ArgumentException(nameof(claimUser));
                }
            }
        }
        public UserAuthentication(IEnumerable<Claim> claims)
        {
            foreach (ClaimAuthentication claimUser in Enum.GetValues(typeof(ClaimAuthentication)))
            {
                var claimAttribute = claimUser.GetAttribute<ClaimAttribute>();
                var selectClaims = claims.Where(x => x.Type == claimAttribute.Name) ?? throw new ArgumentNullException(nameof(claimUser));
                switch (claimUser)
                {
                    case ClaimAuthentication.Id: Id = Guid.Parse(selectClaims.First().Value); break;
                    case ClaimAuthentication.Name: Name = selectClaims.First().Value; break;
                    case ClaimAuthentication.Email: Email = selectClaims.First().Value; break;
                    case ClaimAuthentication.Role: Roles = selectClaims.Select(v => v.Value).ToList(); break;
                    case ClaimAuthentication.Language: break;
                    case ClaimAuthentication.AccessToken: break;
                    default: throw new ArgumentException(nameof(claimUser));
                }
            }
        }
        public IEnumerable<Claim> ToClaims()
        {
            var result = new List<Claim>();
            foreach (ClaimAuthentication claimUser in Enum.GetValues(typeof(ClaimAuthentication)))
            {
                var claimAttribute = claimUser.GetAttribute<ClaimAttribute>();
                switch (claimUser)
                {
                    case ClaimAuthentication.Id: result.Add(new Claim(claimAttribute.Name, Id.ToString())); break;
                    case ClaimAuthentication.Name: result.Add(new Claim(claimAttribute.Name, Name)); break;
                    case ClaimAuthentication.Email: result.Add(new Claim(claimAttribute.Name, Email)); break;
                    case ClaimAuthentication.Role:
                        var roles = Roles.Select(v => new Claim(claimAttribute.Name, v));
                        result.AddRange(roles); break;
                    case ClaimAuthentication.Language: break;
                    case ClaimAuthentication.AccessToken: break;
                    default: throw new ArgumentException(nameof(claimUser));
                }
            }
            return result;
        }
        public IEnumerable<Claim> ToJwtClaims()
        {
            var result = new List<Claim>();
            foreach (JwtClaimAuthentication claimUser in Enum.GetValues(typeof(JwtClaimAuthentication)))
            {
                var claimAttribute = claimUser.GetAttribute<JwtClaimAttribute>();
                switch (claimUser)
                {
                    case JwtClaimAuthentication.Id: result.Add(new Claim(claimAttribute.Name, Id.ToString())); break;
                    case JwtClaimAuthentication.Name: result.Add(new Claim(claimAttribute.Name, Name)); break;
                    case JwtClaimAuthentication.Email: result.Add(new Claim(claimAttribute.Name, Email)); break;
                    case JwtClaimAuthentication.Role:
                        var roles = Roles.Select(v => new Claim(claimAttribute.Name, v));
                        result.AddRange(roles); break;
                    case JwtClaimAuthentication.Language: break;
                    case JwtClaimAuthentication.AccessToken: break;
                    default: throw new ArgumentException(nameof(claimUser));
                }
            }
            return result;
        }
    }
}
