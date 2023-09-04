namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response object for an item chart with a generic data type.
    /// </summary>
    /// <typeparam name="T">The type of data in the chart.</typeparam>
    public class ItemChartResponse<T> : IItemChartResponse<T>
    {
        /// <summary>
        /// Gets or sets the name of the chart.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the data points for the chart.
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemChartResponse{T}"/> class with a name.
        /// </summary>
        /// <param name="name">The name of the chart.</param>
        public ItemChartResponse(string name)
        {
            Name = name;
            Data = new List<T>();
        }
    }
}
