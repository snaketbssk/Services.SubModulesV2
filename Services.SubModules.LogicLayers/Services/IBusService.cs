using Services.SubModules.LogicLayers.MassTransits.Producers;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Interface for a service responsible for sending messages using a bus.
    /// </summary>
    public interface IBusService
    {
        /// <summary>
        /// Sends a message asynchronously using a producer.
        /// </summary>
        /// <param name="containerConsumer">The producer instance used to send the message.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SendAsync(IProducer containerConsumer, CancellationToken cancellationToken = default);
    }
}
