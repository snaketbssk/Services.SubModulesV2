using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request for filtering based on email.
    /// </summary>
    public class EmailRequest : IEmailRequest
    {
        /// <summary>
        /// Gets or sets the email to filter by.
        /// </summary>
        [StringLength(255, MinimumLength = 1)]
        public string? Email { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRequest"/> class.
        /// </summary>
        public EmailRequest()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRequest"/> class with the specified email.
        /// </summary>
        /// <param name="email">The email to filter by.</param>
        public EmailRequest(string email)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
