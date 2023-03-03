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
            Login = name;
            Email = email;
            Roles = roles.Select(x => new RoleResponse(Guid.Empty, x)).ToList();
            AccessToken = accessToken;
            Language = language;
        }
        public UserAuthentication(ClaimsPrincipal claimsPrincipal)
        {
            var values = Enum.GetValues(typeof(ClaimAuthentication));
            foreach (ClaimAuthentication claimUser in values)
            {
                var claimAttribute = claimUser.GetAttribute<ClaimAttribute>();

                var claims = claimsPrincipal.FindAll(claimAttribute.Name) ?? throw new ArgumentNullException(nameof(claimUser));
                switch (claimUser)
                {
                    case ClaimAuthentication.Id: Id = Guid.Parse(claims.First().Value); break;
                    case ClaimAuthentication.Name: Login = claims.FirstOrDefault().Value; break;
                    case ClaimAuthentication.Email: Email = claims.FirstOrDefault().Value; break;
                    case ClaimAuthentication.Role: Roles = claims.Select(v => new RoleResponse(Guid.Empty, v.Value)).ToList(); break;
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
                    case ClaimAuthentication.Name: Login = selectClaims.First().Value; break;
                    case ClaimAuthentication.Email: Email = selectClaims.First().Value; break;
                    case ClaimAuthentication.Role: Roles = selectClaims.Select(v => new RoleResponse(Guid.Empty, v.Value)).ToList(); break;
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
                    case ClaimAuthentication.Name: result.Add(new Claim(claimAttribute.Name, Login)); break;
                    case ClaimAuthentication.Email: result.Add(new Claim(claimAttribute.Name, Email)); break;
                    case ClaimAuthentication.Role:
                        var roles = Roles.Select(v => new Claim(claimAttribute.Name, v.Name));
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
            foreach (IJwtClaimAuthentication claimUser in Enum.GetValues(typeof(IJwtClaimAuthentication)))
            {
                var claimAttribute = claimUser.GetAttribute<JwtClaimAttribute>();
                switch (claimUser)
                {
                    case IJwtClaimAuthentication.Id: result.Add(new Claim(claimAttribute.Name, Id.ToString())); break;
                    case IJwtClaimAuthentication.Name: result.Add(new Claim(claimAttribute.Name, Login)); break;
                    case IJwtClaimAuthentication.Email: result.Add(new Claim(claimAttribute.Name, Email)); break;
                    case IJwtClaimAuthentication.Role:
                        var roles = Roles.Select(v => new Claim(claimAttribute.Name, v.Name));
                        result.AddRange(roles); break;
                    case IJwtClaimAuthentication.Language: break;
                    case IJwtClaimAuthentication.AccessToken: break;
                    default: throw new ArgumentException(nameof(claimUser));
                }
            }
            return result;
        }
    }
}
