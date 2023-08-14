namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for specifying a phone number in requests.
    /// </summary>
    public interface IPhoneRequest
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        string? Phone { get; set; }
    }
}
