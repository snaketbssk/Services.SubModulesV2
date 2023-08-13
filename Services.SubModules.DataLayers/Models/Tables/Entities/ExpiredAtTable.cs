namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    /// <summary>
    /// Represents an abstract base class for database table entities with "CreatedAt" and "ExpiredAt" timestamps.
    /// </summary>
    /// <typeparam name="T">The type of the entity's ID.</typeparam>
    public abstract class ExpiredAtTable<T> : CreatedAtTable<T>, IExpiredAtTable
    {
        /// <summary>
        /// Gets or sets the timestamp indicating when the entity is expired.
        /// </summary>
        public DateTime? ExpiredAt { get; set; }
    }
}
