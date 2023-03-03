using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class UserResponse : BaseTable<Guid>, IUserResponse
    {
        public string? Login { get; set; }
        public string? Email { get; set; }
        public bool? ConfirmedEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? ConfirmedPhoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public List<RoleResponse>? Roles { get; set; }
        public List<ClaimResponse>? Claims { get; set; }

        public UserResponse()
        {

        }

        public UserResponse(Guid id,
                            string? login,
                            string? email,
                            bool? confirmedEmail,
                            string? phoneNumber,
                            bool? confirmedPhoneNumber,
                            bool? twoFactorEnabled,
                            List<RoleResponse> roles,
                            List<ClaimResponse> claims)
        {
            Id = id;
            Login = login;
            Email = email;
            ConfirmedEmail = confirmedEmail;
            PhoneNumber = phoneNumber;
            ConfirmedPhoneNumber = confirmedPhoneNumber;
            TwoFactorEnabled = twoFactorEnabled;
            Roles = roles;
            Claims = claims;
        }
    }
}
