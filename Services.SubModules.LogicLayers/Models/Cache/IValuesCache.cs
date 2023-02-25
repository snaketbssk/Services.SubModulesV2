namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IValuesCache<TValues>
    {
        TValues Value { get; set; }
        bool IsSuccessful { get; set; }
    }
}
