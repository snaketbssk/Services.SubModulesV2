namespace Services.SubModules.DataLayers.Models.Tables
{
    /// <summary>
    /// Represents an interface for a base database table entity.
    /// </summary>
    /// <typeparam name="T">The type of the entity's ID.</typeparam>
    public interface IBaseTable<T>
    {
        /// <summary>
        /// Gets or sets the primary key of the entity.
        /// </summary>
        T Id { get; set; }
    }
}
