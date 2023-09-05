namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a chart response object with categories and series data.
    /// </summary>
    /// <typeparam name="T">The type of data in the chart series.</typeparam>
    public class ChartResponse : IChartResponse
    {
        /// <summary>
        /// Gets or sets the name for the chart
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description for the chart
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the categories for the chart.
        /// </summary>
        public List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the series data for the chart.
        /// </summary>
        public List<ItemChartResponse> Series { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartResponse{T}"/> class with categories and series data.
        /// </summary>
        /// <param name="categories">The categories for the chart.</param>
        /// <param name="series">The series data for the chart.</param>
        public ChartResponse(string name, string description, List<string> categories, params ItemChartResponse[] series)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentException.ThrowIfNullOrEmpty(description, nameof(description));

            // Check if Categories is null and throw ArgumentNullException if it is.
            ArgumentNullException.ThrowIfNull(categories, nameof(categories));

            // Check if Series is null and throw ArgumentNullException if it is.
            ArgumentNullException.ThrowIfNull(series, nameof(series));

            Name = name;
            Description = description;
            Categories = categories;
            Series = series.ToList();

            Validate();
        }

        /// <summary>
        /// Validates the integrity of chart data.
        /// </summary>
        private void Validate()
        {
            // Validate each category in the Categories list.
            foreach (var category in Categories)
            {
                // Check if a category is null and throw ArgumentNullException if it is.
                ArgumentNullException.ThrowIfNull(category, nameof(category));
            }

            // Validate each series in the Series list.
            foreach (var series in Series)
            {
                // Check if a series is null and throw ArgumentNullException if it is.
                ArgumentNullException.ThrowIfNull(series, nameof(series));

                // Check if the Name property of the series is null or empty and throw ArgumentException if it is.
                ArgumentException.ThrowIfNullOrEmpty(series.Name, nameof(series.Name));

                // Check if the Data property of the series is null and throw ArgumentNullException if it is.
                ArgumentNullException.ThrowIfNull(series.Data, nameof(series.Data));

                // Validate each data item in the Data list of the series.
                foreach (var data in series.Data)
                {
                    // Check if a data item is null and throw ArgumentNullException if it is.
                    ArgumentNullException.ThrowIfNull(data, nameof(data));
                }

                // Check if the count of Categories is not equal to the count of Data in the series and throw ArgumentException if they are not equal.
                if (Categories.Count != series.Data.Count)
                {
                    throw new ArgumentException(nameof(Categories.Count));
                }
            }
        }

    }
}
