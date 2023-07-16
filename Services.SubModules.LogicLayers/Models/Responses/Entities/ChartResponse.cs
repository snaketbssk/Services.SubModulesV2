using Services.SubModules.LogicLayers.Constants;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class ChartResponse : IChartResponse
    {
        public List<string> Labels { get; set; }
        public List<decimal> Values { get; set; }
        public int TotalCount { get; set; }

        public ChartResponse()
        {
            Labels = new List<string>();
            Values = new List<decimal>();
        }

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

        public ChartResponse(IEnumerable<DateTime> labels, IEnumerable<decimal> values)
            : this(labels.Select(x => x.ToString(DatetimeConstant.FORMAT)), values)
        {
        }

        public void Add(string label, decimal value)
        {
            ArgumentNullException.ThrowIfNull(label, nameof(label));
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            Labels.Add(label);
            Values.Add(value);
        }

        public void Add(DateTime label, decimal value)
        {
            ArgumentNullException.ThrowIfNull(label, nameof(label));
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            Labels.Add(label.ToString(DatetimeConstant.FORMAT));
            Values.Add(value);
        }
    }
}
