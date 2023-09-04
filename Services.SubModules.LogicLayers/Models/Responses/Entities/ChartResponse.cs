using Services.SubModules.LogicLayers.Constants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a chart response object with categories and series data.
    /// </summary>
    /// <typeparam name="T">The type of data in the chart series.</typeparam>
    public class ChartResponse<T> : IChartResponse<T>
    {
        /// <summary>
        /// Gets or sets the categories for the chart.
        /// </summary>
        public List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the series data for the chart.
        /// </summary>
        public List<ItemChartResponse<T>> Series { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartResponse{T}"/> class with categories and series data.
        /// </summary>
        /// <param name="categories">The categories for the chart.</param>
        /// <param name="series">The series data for the chart.</param>
        public ChartResponse(List<string> categories, List<ItemChartResponse<T>> series)
        {
            Categories = categories;
            Series = series;

            Validate();
        }

        /// <summary>
        /// Validates the integrity of chart data.
        /// </summary>
        private void Validate()
        {
            // Check if Categories is null and throw ArgumentNullException if it is.
            ArgumentNullException.ThrowIfNull(Categories, nameof(Categories));

            // Check if Series is null and throw ArgumentNullException if it is.
            ArgumentNullException.ThrowIfNull(Series, nameof(Series));

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
