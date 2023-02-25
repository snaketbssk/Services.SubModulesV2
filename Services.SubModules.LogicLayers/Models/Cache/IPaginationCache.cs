namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IPaginationCache<TValue>
    {
        IEnumerable<TValue> Values { get; set; }
        int TotalCount { get; set; }
        bool IsSuccessful { get; set; }
    }
}
