using Services.SubModules.DataLayers.Models.Tables;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for role response models.
    /// </summary>
    public interface IRoleResponse : IBaseTable<Guid>
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        string Name { get; set; }
    }
}
