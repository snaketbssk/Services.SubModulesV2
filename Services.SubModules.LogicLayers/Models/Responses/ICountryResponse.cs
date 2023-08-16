using Services.SubModules.DataLayers.Models.Tables;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for country response models.
    /// </summary>
    public interface ICountryResponse : IBaseTable<Guid>
    {
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        string? Name { get; set; }

        /// <summary>
        /// Gets or sets the ISO 2-letter code of the country.
        /// </summary>
        string? Iso2 { get; set; }

        /// <summary>
        /// Gets or sets the ISO 3-letter code of the country.
        /// </summary>
        string? Iso3 { get; set; }
    }
}
