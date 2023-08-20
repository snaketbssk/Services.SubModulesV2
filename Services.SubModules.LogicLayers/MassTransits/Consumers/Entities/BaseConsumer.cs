using MassTransit;

namespace Services.SubModules.LogicLayers.MassTransits.Consumers.Entities
{
    /// <summary>
    /// Abstract base class for MassTransit message consumers that handle messages of a specific type.
    /// </summary>
    /// <typeparam name="TMessage">The type of message that the consumer handles.</typeparam>
    public abstract class BaseConsumer<TMessage> : IConsumer<TMessage> where TMessage : class
    {
        /// <summary>
        /// This method is called when a message of type <typeparamref name="TMessage"/> is received by the consumer.
        /// Subclasses must implement this method to define the behavior of handling the message.
        /// </summary>
        /// <param name="context">The context containing the received message and associated information.</param>
        /// <returns>A task representing the asynchronous handling of the message.</returns>
        public abstract Task Consume(ConsumeContext<TMessage> context);
    }
}
