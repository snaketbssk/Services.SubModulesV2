namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IRepositoryCache
    {
        string Project { get; }
        string Container { get; }
        TimeSpan? Expiry { get; }
    }
}
