using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response containing data for a chart.
    /// </summary>
    public class ChartResponse : IChartResponse
    {
        /// <summary>
        /// Gets or sets the labels for the chart.
        /// </summary>
        public List<string> Labels { get; set; }

        /// <summary>
        /// Gets or sets the values for the chart.
        /// </summary>
        public List<decimal> Values { get; set; }

        /// <summary>
        /// Gets or sets the total count of chart data points.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartResponse"/> class.
        /// </summary>
        public ChartResponse()
        {
            Labels = new List<string>();
            Values = new List<decimal>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartResponse"/> class.
        /// </summary>
        /// <param name="labels">The labels for the chart.</param>
        /// <param name="values">The values for the chart.</param>
        public ChartResponse(IEnumerable<string> labels, IEnumerable<decimal> values)
        {
            ArgumentNullException.ThrowIfNull(labels, nameof(labels));
            ArgumentNullException.ThrowIfNull(values, nameof(values));
            if (!labels.Any())
                throw new ArgumentOutOfRangeException(nameof(labels));
            if (!values.Any())
                throw new ArgumentOutOfRangeException(nameof(values));

            var countLabels = labels.Count();
            var countValues = values.Count();
            if (countLabels != countValues)
                throw new ArgumentOutOfRangeException("Count");

            Labels = new List<string>(labels);
            Values = new List<decimal>(values);
            TotalCount = countLabels;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartResponse"/> class.
        /// </summary>
        /// <param name="labels">The labels for the chart as dates.</param>
        /// <param name="values">The values for the chart.</param>
        public ChartResponse(IEnumerable<DateTime> labels, IEnumerable<decimal> values)
            : this(labels.Select(x => x.ToString(DatetimeConstant.FORMAT)), values)
        {
        }

        /// <summary>
        /// Adds a data point to the chart.
        /// </summary>
        /// <param name="label">The label for the data point.</param>
        /// <param name="value">The value for the data point.</param>
        public void Add(string label, decimal value)
        {
            ArgumentNullException.ThrowIfNull(label, nameof(label));
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            Labels.Add(label);
            Values.Add(value);
        }

        /// <summary>
        /// Adds a data point to the chart.
        /// </summary>
        /// <param name="label">The label for the data point (as a date).</param>
        /// <param name="value">The value for the data point.</param>
        public void Add(DateTime label, decimal value)
        {
            ArgumentNullException.ThrowIfNull(label, nameof(label));
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            Labels.Add(label.ToString(DatetimeConstant.FORMAT));
            Values.Add(value);
        }
    }
}
