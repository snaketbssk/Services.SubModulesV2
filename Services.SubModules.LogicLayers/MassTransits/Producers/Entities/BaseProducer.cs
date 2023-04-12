using MassTransit;
using Services.SubModules.LogicLayers.MassTransits.Entities;

namespace Services.SubModules.LogicLayers.MassTransits.Producers.Entities
{
    public abstract class BaseProducer<TMessage, TConsumer>
        : BaseMassTransit<TMessage, TConsumer>, IProducer
        where TMessage : class
        where TConsumer : IConsumer<TMessage>
    {
        public TMessage Message { set; get; }

        protected BaseProducer(TMessage message)
        {
            Message = message;
        }

        public async Task SendAsync(IBus bus, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(Message, nameof(Message));
            ArgumentNullException.ThrowIfNull(bus, nameof(bus));

            var endpoint = await bus.GetSendEndpoint(new Uri($"queue:{QueuePath}"));
            await endpoint.Send(Message, cancellationToken);
        }
    }
}
