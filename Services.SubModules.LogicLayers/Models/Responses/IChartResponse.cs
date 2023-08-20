namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for chart response models.
    /// </summary>
    public interface IChartResponse
    {
        /// <summary>
        /// Gets or sets the labels for the chart.
        /// </summary>
        List<string> Labels { get; set; }

        /// <summary>
        /// Gets or sets the values associated with the chart.
        /// </summary>
        List<decimal> Values { get; set; }

        /// <summary>
        /// Gets or sets the total count of items in the chart.
        /// </summary>
        int TotalCount { get; set; }
    }
}
