namespace Services.SubModules.DataLayers.Models.Tables
{
    /// <summary>
    /// Represents an interface for a database table entity with a "CreatedAt" timestamp.
    /// </summary>
    public interface ICreatedAtTable
    {
        /// <summary>
        /// Gets or sets the timestamp indicating when the entity was created.
        /// </summary>
        DateTime? CreatedAt { get; set; }
    }
}
