using MassTransit;

namespace Services.SubModules.LogicLayers.MassTransits.Consumers.Entities
{
    public abstract class BaseConsumer<TMessage> : IConsumer<TMessage> where TMessage : class
    {
        public abstract Task Consume(ConsumeContext<TMessage> context);
    }
}
