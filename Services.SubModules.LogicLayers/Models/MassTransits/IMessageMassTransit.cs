namespace Services.SubModules.LogicLayers.Models.MassTransits
{
    public interface IMessageMassTransit<T>
    {
        List<T> Values { get; set; }
    }
}
