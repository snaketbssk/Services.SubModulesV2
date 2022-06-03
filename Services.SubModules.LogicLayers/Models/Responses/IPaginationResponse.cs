namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IPaginationResponse<T>
    {
        int TotalCount { get; }
        List<T> Values { get; }
    }
}
