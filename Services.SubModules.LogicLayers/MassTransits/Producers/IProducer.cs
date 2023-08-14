using MassTransit;
using System.Threading;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.MassTransits.Producers
{
    /// <summary>
    /// Represents a message producer interface that defines a method for sending messages.
    /// </summary>
    public interface IProducer
    {
        /// <summary>
        /// Sends a message using the provided MassTransit bus instance.
        /// </summary>
        /// <param name="bus">The MassTransit bus instance used for sending the message.</param>
        /// <param name="cancellationToken">A cancellation token for the async operation.</param>
        /// <returns>A task representing the asynchronous sending of the message.</returns>
        Task SendAsync(IBus bus, CancellationToken cancellationToken = default);
    }
}
