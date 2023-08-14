using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response containing information about a country.
    /// </summary>
    public class CountryResponse : BaseTable<Guid>, ICountryResponse
    {
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the ISO 2-letter code of the country.
        /// </summary>
        public string? Iso2 { get; set; }

        /// <summary>
        /// Gets or sets the ISO 3-letter code of the country.
        /// </summary>
        public string? Iso3 { get; set; }
    }
}
