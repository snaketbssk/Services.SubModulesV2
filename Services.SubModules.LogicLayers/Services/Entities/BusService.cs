using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.MassTransits.Buses;
using Services.SubModules.LogicLayers.MassTransits.Producers;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for sending messages through a service bus.
    /// </summary>
    public class BusService : BaseService, IBusService
    {
        private readonly IServiceBus _bus;

        /// <summary>
        /// Initializes a new instance of the BusService class.
        /// </summary>
        /// <param name="httpContextAccessor">The IHttpContextAccessor used to access the HttpContext.</param>
        /// <param name="bus">The service bus instance used for message communication.</param>
        public BusService(IHttpContextAccessor httpContextAccessor, IServiceBus bus)
            : base(httpContextAccessor)
        {
            _bus = bus;
        }

        /// <summary>
        /// Sends a message using the specified producer and service bus.
        /// </summary>
        /// <param name="producer">The producer responsible for sending the message.</param>
        /// <param name="cancellationToken">A cancellation token to observe.</param>
        public async Task SendAsync(IProducer producer, CancellationToken cancellationToken = default)
        {
            await producer.SendAsync(_bus, cancellationToken);
        }
    }
}
