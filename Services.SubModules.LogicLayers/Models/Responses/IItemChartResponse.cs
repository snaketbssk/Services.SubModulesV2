namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents a response object for an item chart with a generic data type.
    /// </summary>
    /// <typeparam name="T">The type of data in the chart.</typeparam>
    public interface IItemChartResponse
    {
        /// <summary>
        /// Gets or sets the name of the chart.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the data points for the chart.
        /// </summary>
        List<decimal> Data { get; set; }
    }
}
