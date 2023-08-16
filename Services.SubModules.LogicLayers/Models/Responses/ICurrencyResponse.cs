using Services.SubModules.DataLayers.Models.Tables;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for currency response models.
    /// </summary>
    public interface ICurrencyResponse : IBaseTable<Guid>
    {
        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        string? Code { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        string? Symbol { get; set; }

        /// <summary>
        /// Gets or sets the numeric currency code.
        /// </summary>
        int? Number { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        string? Name { get; set; }

        /// <summary>
        /// Gets or sets whether the currency is enabled.
        /// </summary>
        bool Enable { get; set; }
    }
}
