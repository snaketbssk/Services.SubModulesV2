using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.MassTransits.Buses;
using Services.SubModules.LogicLayers.MassTransits.Producers;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class BusService : BaseService, IBusService
    {
        private readonly IServiceBus _bus;

        public BusService(IHttpContextAccessor httpContextAccessor, IServiceBus bus)
            : base(httpContextAccessor)
        {
            _bus = bus;
        }

        public async Task SendAsync(IProducer producer, CancellationToken cancellationToken = default)
        {
            await producer.SendAsync(_bus, cancellationToken);
        }
    }
}
