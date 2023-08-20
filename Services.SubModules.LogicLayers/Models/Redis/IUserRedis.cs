using Services.SubModules.LogicLayers.Models.Redis.Entities;

namespace Services.SubModules.LogicLayers.Models.Redis
{
    /// <summary>
    /// Represents a user stored in Redis cache.
    /// </summary>
    public interface IUserRedis
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        string? Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        string? Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's email is confirmed.
        /// </summary>
        bool ConfirmedEmail { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's phone number is confirmed.
        /// </summary>
        bool ConfirmedPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether two-factor authentication is enabled for the user.
        /// </summary>
        bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the claims associated with the user.
        /// </summary>
        List<ClaimRedis> Claims { get; set; }
    }
}
