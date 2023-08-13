namespace Services.SubModules.DataLayers.Models.Tables
{
    /// <summary>
    /// Represents an interface for a database table entity with an "IdUser" property.
    /// </summary>
    /// <typeparam name="T">The type of the "IdUser" property.</typeparam>
    public interface IIdUserTable<T>
    {
        /// <summary>
        /// Gets or sets the identifier for the user associated with the entity.
        /// </summary>
        T IdUser { get; set; }
    }
}
