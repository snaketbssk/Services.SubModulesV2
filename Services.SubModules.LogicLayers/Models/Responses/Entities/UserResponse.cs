using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response model for users.
    /// </summary>
    public class UserResponse : BaseTable<Guid>, IUserResponse
    {
        /// <summary>
        /// Gets or sets the user's login.
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets whether the user's email has been confirmed.
        /// </summary>
        public bool? ConfirmedEmail { get; set; }

        /// <summary>
        /// Gets or sets the user's phone number.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets whether the user's phone number has been confirmed.
        /// </summary>
        public bool? ConfirmedPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets whether two-factor authentication is enabled for the user.
        /// </summary>
        public bool? TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the list of roles associated with the user.
        /// </summary>
        public List<RoleResponse>? Roles { get; set; }

        /// <summary>
        /// Gets or sets the list of claims associated with the user.
        /// </summary>
        public List<ClaimResponse>? Claims { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserResponse"/> class.
        /// </summary>
        public UserResponse()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserResponse"/> class with the specified parameters.
        /// </summary>
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
