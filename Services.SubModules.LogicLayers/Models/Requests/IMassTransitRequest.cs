namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IMassTransitRequest<T>
    {
        List<T> Values { get; set; }
    }
}
