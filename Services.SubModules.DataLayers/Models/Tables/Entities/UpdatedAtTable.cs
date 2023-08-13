namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    /// <summary>
    /// Represents an abstract base class for database table entities with "CreatedAt" and "UpdatedAt" timestamps.
    /// </summary>
    /// <typeparam name="T">The type of the entity's ID.</typeparam>
    public abstract class UpdatedAtTable<T> : CreatedAtTable<T>, IUpdatedAtTable
    {
        /// <summary>
        /// Gets or sets the timestamp indicating when the entity was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
