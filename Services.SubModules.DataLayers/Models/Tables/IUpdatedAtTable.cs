namespace Services.SubModules.DataLayers.Models.Tables
{
    /// <summary>
    /// Represents an interface for a database table entity with an "UpdatedAt" timestamp.
    /// </summary>
    public interface IUpdatedAtTable
    {
        /// <summary>
        /// Gets or sets the timestamp indicating when the entity was last updated.
        /// </summary>
        DateTime? UpdatedAt { get; set; }
    }
}
