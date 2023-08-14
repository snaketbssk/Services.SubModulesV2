namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for request classes that include an email address.
    /// </summary>
    public interface IEmailRequest
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        string? Email { get; set; }
    }
}
