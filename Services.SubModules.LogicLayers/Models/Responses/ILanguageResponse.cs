using Services.SubModules.DataLayers.Models.Tables;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for language response models.
    /// </summary>
    public interface ILanguageResponse : IBaseTable<Guid>
    {
        /// <summary>
        /// Gets or sets the name of the language.
        /// </summary>
        string? Name { get; set; }

        /// <summary>
        /// Gets or sets the code associated with the language.
        /// </summary>
        string? Code { get; set; }
    }
}
