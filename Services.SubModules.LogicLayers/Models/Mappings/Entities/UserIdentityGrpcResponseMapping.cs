using Google.Protobuf;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class UserIdentityGrpcResponseMapping : Mapping<UserIdentityGrpcResponse>
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
        public bool ConfirmedPhone { get; set; }
        public bool ConfirmedTwoFactorAuthentication { get; set; }
        public IEnumerable<RoleIdentityGrpcResponseMapping> Roles { get; set; }
        public UserIdentityGrpcResponseMapping(
            Guid id,
            string login,
            string email,
            bool confirmedEmail,
            bool confirmedPhone,
            bool confirmedTwoFactorAuthentication,
            IEnumerable<RoleIdentityGrpcResponseMapping> roles)
        {
            Id = id;
            Login = login;
            Email = email;
            ConfirmedEmail = confirmedEmail;
            ConfirmedPhone = confirmedPhone;
            ConfirmedTwoFactorAuthentication = confirmedTwoFactorAuthentication;
            Roles = roles;
        }
        public override UserIdentityGrpcResponse Map()
        {
            var result = new UserIdentityGrpcResponse
            {
                Id = ByteString.CopyFrom(Id.ToByteArray()),
                Login = Login,
                Email = Email,
                ConfirmedEmail = ConfirmedEmail,
                ConfirmedPhone = ConfirmedPhone,
                ConfirmedTwoFactorAuthentication = ConfirmedTwoFactorAuthentication
            };
            var roles = Roles.Select(x => x.Map());
            result.Roles.AddRange(roles);
            return result;
        }

        public override UserIdentityGrpcResponse Update(UserIdentityGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
