using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class ChartResponse : IChartResponse
    {
        public IEnumerable<string> Labels { get; set; }
        public IEnumerable<decimal> Values { get; set; }
        public int TotalCount { get; set; }

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

            Labels = labels;
            Values = values;
            TotalCount = countLabels;
        }

        public ChartResponse(IEnumerable<DateTime> labels, IEnumerable<decimal> values)
            : this(labels.Select(x => x.ToString(DatetimeConstant.FORMAT)), values)
        {
        }
    }
}
