namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request for filtering based on creation date.
    /// </summary>
    public class CreatedAtRequest : ICreatedAtRequest
    {
        /// <summary>
        /// Gets or sets the creation date to filter by.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
