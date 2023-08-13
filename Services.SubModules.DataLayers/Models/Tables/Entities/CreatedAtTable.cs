namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    /// <summary>
    /// Represents an abstract base class for database table entities with a "CreatedAt" timestamp.
    /// </summary>
    /// <typeparam name="T">The type of the entity's ID.</typeparam>
    public abstract class CreatedAtTable<T> : BaseTable<T>, ICreatedAtTable
    {
        /// <summary>
        /// Gets or sets the timestamp indicating when the entity was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }
    }
}
