using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response containing information about a currency.
    /// </summary>
    public class CurrencyResponse : BaseTable<Guid>, ICurrencyResponse
    {
        /// <summary>
        /// Gets or sets the code of the currency.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the symbol of the currency.
        /// </summary>
        public string? Symbol { get; set; }

        /// <summary>
        /// Gets or sets the numeric code of the currency.
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets whether the currency is enabled.
        /// </summary>
        public bool Enable { get; set; }
    }
}
