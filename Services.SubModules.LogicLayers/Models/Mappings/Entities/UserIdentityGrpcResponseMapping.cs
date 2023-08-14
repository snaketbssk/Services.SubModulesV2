using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to UserIdentityGrpcResponse.
    /// </summary>
    public class UserIdentityGrpcResponseMapping : Mapping<UserIdentityGrpcResponse>
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user's login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's email is confirmed.
        /// </summary>
        public bool ConfirmedEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's phone number is confirmed.
        /// </summary>
        public bool ConfirmedPhone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has confirmed two-factor authentication.
        /// </summary>
        public bool ConfirmedTwoFactorAuthentication { get; set; }

        /// <summary>
        /// Gets or sets the user's roles.
        /// </summary>
        public IEnumerable<RoleIdentityGrpcResponseMapping> Roles { get; set; }

        /// <summary>
        /// Gets or sets the user's claims.
        /// </summary>
        public IEnumerable<ClaimRoleIdentityGrpcResponseMapping> Claims { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIdentityGrpcResponseMapping"/> class.
        /// </summary>
        public UserIdentityGrpcResponseMapping(
            Guid id,
            string login,
            string email,
            bool confirmedEmail,
            bool confirmedPhone,
            bool confirmedTwoFactorAuthentication,
            IEnumerable<RoleIdentityGrpcResponseMapping> roles,
            IEnumerable<ClaimRoleIdentityGrpcResponseMapping> claims)
        {
            Id = id;
            Login = login;
            Email = email;
            ConfirmedEmail = confirmedEmail;
            ConfirmedPhone = confirmedPhone;
            ConfirmedTwoFactorAuthentication = confirmedTwoFactorAuthentication;
            Roles = roles;
            Claims = claims;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of UserIdentityGrpcResponse.
        /// </summary>
        /// <returns>The mapped instance of UserIdentityGrpcResponse.</returns>
        public override UserIdentityGrpcResponse Map()
        {
            var result = new UserIdentityGrpcResponse
            {
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

        /// <summary>
        /// Updates an existing instance of UserIdentityGrpcResponse with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of UserIdentityGrpcResponse to be updated.</param>
        /// <returns>The updated instance of UserIdentityGrpcResponse.</returns>
        public override UserIdentityGrpcResponse Update(UserIdentityGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
