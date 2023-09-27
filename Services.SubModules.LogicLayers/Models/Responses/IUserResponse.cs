using Services.SubModules.DataLayers.Models.Tables;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for user response models.
    /// </summary>
    public interface IUserResponse : IBaseTable<Guid>
    {
        /// <summary>
        /// Gets or sets the user's login.
        /// </summary>
        string? Login { get; set; }

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        string? Email { get; set; }

        /// <summary>
        /// Gets or sets whether the user's email has been confirmed.
        /// </summary>
        bool? ConfirmedEmail { get; set; }

        /// <summary>
        /// Gets or sets the user's phone number.
        /// </summary>
        string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets whether the user's phone number has been confirmed.
        /// </summary>
        bool? ConfirmedPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets whether two-factor authentication is enabled for the user.
        /// </summary>
        bool? TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the list of roles associated with the user.
        /// </summary>
        List<RoleResponse>? Roles { get; set; }

        /// <summary>
        /// Gets or sets the list of claims associated with the user.
        /// </summary>
        List<ClaimResponse>? Claims { get; set; }

        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the person.
        /// </summary>
        string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the sur name of the person.
        /// </summary>
        string? Surname { get; set; }

        /// <summary>
        /// Gets or sets the patronymic of the person.
        /// </summary>
        string? Patronymic { get; set; }

        /// <summary>
        /// Gets or sets the patronymic of the person.
        /// </summary>
        string? Matronymic { get; set; }

        /// <summary>
        /// Gets or sets the preferred language of the person.
        /// </summary>
        string? Language { get; set; }

        /// <summary>
        /// Gets or sets the address of the person.
        /// </summary>
        string? Address { get; set; }

        /// <summary>
        /// Gets or sets the ZIP code of the person.
        /// </summary>
        string? ZipCode { get; set; }
    }
}
