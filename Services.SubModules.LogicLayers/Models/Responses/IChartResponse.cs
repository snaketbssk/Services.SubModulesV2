namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IChartResponse
    {
        IEnumerable<string> Labels { get; set; }
        IEnumerable<decimal> Values { get; set; }
        int TotalCount { get; set; }
    }
}
