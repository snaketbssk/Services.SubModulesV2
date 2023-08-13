using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    /// <summary>
    /// Represents the base class for database table entities.
    /// </summary>
    /// <typeparam name="T">The type of the entity's ID.</typeparam>
    public abstract class BaseTable<T> : IBaseTable<T>
    {
        /// <summary>
        /// Gets or sets the primary key of the entity.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
    }
}
