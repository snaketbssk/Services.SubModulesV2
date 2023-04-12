using MassTransit;

namespace Services.SubModules.LogicLayers.MassTransits.Producers
{
    public interface IProducer
    {
        Task SendAsync(IBus bus, CancellationToken cancellationToken = default);
    }
}
