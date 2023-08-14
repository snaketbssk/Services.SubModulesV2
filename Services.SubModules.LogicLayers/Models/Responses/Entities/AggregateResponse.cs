namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents an aggregated response containing information about an aggregate operation.
    /// </summary>
    public class AggregateResponse : IAggregateResponse
    {
        /// <summary>
        /// Gets or sets the aggregated amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the starting date of the aggregation period.
        /// </summary>
        public DateTime FromAggregateAt { get; set; }

        /// <summary>
        /// Gets or sets the ending date of the aggregation period.
        /// </summary>
        public DateTime ToAggregateAt { get; set; }
    }
}
