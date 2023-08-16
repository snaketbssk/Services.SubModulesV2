using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response containing language information.
    /// </summary>
    public class LanguageResponse : BaseTable<Guid>, ILanguageResponse
    {
        /// <summary>
        /// Gets or sets the name of the language.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the language.
        /// </summary>
        public string? Code { get; set; }
    }
}
