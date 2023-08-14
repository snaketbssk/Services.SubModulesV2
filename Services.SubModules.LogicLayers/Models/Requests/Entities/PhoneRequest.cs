using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request for a phone number.
    /// </summary>
    public class PhoneRequest : IPhoneRequest
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [StringLength(255, MinimumLength = 1)]
        public string? Phone { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneRequest"/> class.
        /// </summary>
        public PhoneRequest()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneRequest"/> class with a phone number.
        /// </summary>
        /// <param name="phone">The phone number.</param>
        public PhoneRequest(string phone)
        {
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }
    }
}
