namespace Services.SubModules.DataLayers.Models.Tables
{
    /// <summary>
    /// Represents an interface for a database table entity with an "ExpiredAt" timestamp.
    /// </summary>
    public interface IExpiredAtTable
    {
        /// <summary>
        /// Gets or sets the timestamp indicating when the entity is expired.
        /// </summary>
        DateTime? ExpiredAt { get; set; }
    }
}
