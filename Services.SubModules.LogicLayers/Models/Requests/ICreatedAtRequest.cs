namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for request classes that include a creation timestamp.
    /// </summary>
    public interface ICreatedAtRequest
    {
        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        DateTime CreatedAt { get; set; }
    }
}
