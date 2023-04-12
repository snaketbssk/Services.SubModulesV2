using Services.SubModules.LogicLayers.MassTransits.Producers;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IBusService
    {
        Task SendAsync(IProducer containerConsumer, CancellationToken cancellationToken = default);
    }
}
