using MassTransit;
using Services.SubModules.LogicLayers.MassTransits.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.MassTransits.Producers.Entities
{
    /// <summary>
    /// Abstract base class for MassTransit message producers that send messages of a specific type.
    /// </summary>
    /// <typeparam name="TMessage">The type of message that the producer sends.</typeparam>
    public abstract class BaseProducer<TMessage>
        : BaseMassTransit<TMessage>, IProducer
        where TMessage : class
    {
        /// <summary>
        /// Gets or sets the message to be sent by the producer.
        /// </summary>
        public TMessage Message { set; get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseProducer{TMessage}"/> class with the specified message.
        /// </summary>
        /// <param name="message">The message to be sent by the producer.</param>
        protected BaseProducer(TMessage message)
        {
            Message = message;
        }

        /// <summary>
        /// Sends the stored message using the provided bus.
        /// </summary>
        /// <param name="bus">The MassTransit bus instance used for sending the message.</param>
        /// <param name="cancellationToken">A cancellation token for the async operation.</param>
        public async Task SendAsync(IBus bus, CancellationToken cancellationToken = default)
        {
            // Ensure the message and bus are not null
            ArgumentNullException.ThrowIfNull(Message, nameof(Message));
            ArgumentNullException.ThrowIfNull(bus, nameof(bus));

            // Get the send endpoint based on the queue path and send the message
            var endpoint = await bus.GetSendEndpoint(new Uri($"queue:{QueuePath}"));
            await endpoint.Send(Message, cancellationToken);
        }
    }
}
