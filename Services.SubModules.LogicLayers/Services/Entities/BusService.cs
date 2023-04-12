using MassTransit;
using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.MassTransits.Producers;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class BusService : BaseService, IBusService
    {
        private readonly IBus _bus;

        public BusService(IHttpContextAccessor httpContextAccessor, IBus bus)
            : base(httpContextAccessor)
        {
            _bus = bus;
        }

        public async Task SendAsync(IProducer containerConsumer, CancellationToken cancellationToken = default)
        {
            await containerConsumer.SendAsync(_bus, cancellationToken);
        }
    }
}
