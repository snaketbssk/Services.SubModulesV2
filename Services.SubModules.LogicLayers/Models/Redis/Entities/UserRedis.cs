using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Redis.Entities
{
    /// <summary>
    /// Represents a user stored in Redis cache, inheriting from the base table entity.
    /// </summary>
    public class UserRedis : BaseTable<Guid>, IUserRedis
    {
        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's email is confirmed.
        /// </summary>
        public bool ConfirmedEmail { get; set; }

        /// <summary>
        /// Gets or sets the user's phone number.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the person.
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the sur name of the person.
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Gets or sets the patronymic of the person.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Gets or sets the patronymic of the person.
        /// </summary>
        public string? Matronymic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's phone number is confirmed.
        /// </summary>
        public bool ConfirmedPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether two-factor authentication is enabled for the user.
        /// </summary>
        public bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the list of claims associated with the user.
        /// </summary>
        public List<ClaimRedis> Claims { get; set; }

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
