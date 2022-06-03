namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IPaginationRequest
    {
        int From { get; set; }
        int To { get; set; }
        int Take(int max = 100);
    }
}
