namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for requests containing a name.
    /// </summary>
    public interface INameRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }
    }
}
