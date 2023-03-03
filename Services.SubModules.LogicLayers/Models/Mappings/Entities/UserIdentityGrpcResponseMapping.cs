using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class UserIdentityGrpcResponseMapping : Mapping<UserIdentityGrpcResponse>
    {
        public bool IsSuccess { get; set; }
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
        public bool ConfirmedPhone { get; set; }
        public bool ConfirmedTwoFactorAuthentication { get; set; }
        public IEnumerable<RoleIdentityGrpcResponseMapping> Roles { get; set; }
        public IEnumerable<ClaimRoleIdentityGrpcResponseMapping> Claims { get; set; }
        public UserIdentityGrpcResponseMapping(
            bool isSuccess,
            Guid id,
            string login,
            string email,
            bool confirmedEmail,
            bool confirmedPhone,
            bool confirmedTwoFactorAuthentication,
            IEnumerable<RoleIdentityGrpcResponseMapping> roles,
            IEnumerable<ClaimRoleIdentityGrpcResponseMapping> claims)
        {
            IsSuccess = isSuccess;
            Id = id;
            Login = login;
            Email = email;
            ConfirmedEmail = confirmedEmail;
            ConfirmedPhone = confirmedPhone;
            ConfirmedTwoFactorAuthentication = confirmedTwoFactorAuthentication;
            Roles = roles;
            Claims = claims;
        }
        public override UserIdentityGrpcResponse Map()
        {
            var result = new UserIdentityGrpcResponse
            {
                IsSuccess = IsSuccess,
                Id = Id.ToString(),
                Login = Login,
                Email = Email,
                ConfirmedEmail = ConfirmedEmail,
                ConfirmedPhoneNumber = ConfirmedPhone,
                TwoFactorEnabled = ConfirmedTwoFactorAuthentication
            };
            var roles = Roles.Select(x => x.Map());
            var claims = Claims.Select(x => x.Map());
            result.Roles.AddRange(roles);
            result.Claims.AddRange(claims);
            return result;
        }

        public override UserIdentityGrpcResponse Update(UserIdentityGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
