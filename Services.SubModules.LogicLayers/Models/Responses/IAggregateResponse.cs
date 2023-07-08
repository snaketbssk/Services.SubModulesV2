namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IAggregateResponse
    {
        decimal Amount { get; set; }
        DateTime FromAggregateAt { get; set; }
        DateTime ToAggregateAt { get; set; }
    }
}