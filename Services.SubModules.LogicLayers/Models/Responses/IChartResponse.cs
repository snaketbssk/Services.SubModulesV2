namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IChartResponse
    {
        List<string> Labels { get; set; }
        List<decimal> Values { get; set; }
        int TotalCount { get; set; }
    }
}
