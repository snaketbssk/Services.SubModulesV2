namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class AggregateResponse : IAggregateResponse
    {
        public decimal Amount { get; set; }
        public DateTime FromAggregateAt { get; set; }
        public DateTime ToAggregateAt { get; set; }
    }
}
