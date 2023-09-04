using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents a generic interface for chart responses with categories and series data.
    /// </summary>
    /// <typeparam name="T">The type of data in the chart series.</typeparam>
    public interface IChartResponse<T>
    {
        /// <summary>
        /// Gets or sets the categories for the chart.
        /// </summary>
        List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the series data for the chart.
        /// </summary>
        List<ItemChartResponse<T>> Series { get; set; }
    }
}
