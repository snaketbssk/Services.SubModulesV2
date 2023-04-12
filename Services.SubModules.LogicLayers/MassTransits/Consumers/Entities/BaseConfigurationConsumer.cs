using MassTransit;
using Services.SubModules.LogicLayers.MassTransits.Entities;

namespace Services.SubModules.LogicLayers.MassTransits.Consumers.Entities
{
    public abstract class BaseConfigurationConsumer<TMessage, TConsumer>
        : BaseMassTransit<TMessage, TConsumer>, IConfigurationConsumer
        where TMessage : class
        where TConsumer : IConsumer<TMessage>
    {
        public abstract int RetryCount { get; }

        public abstract int PrefetchCount { get; }

        public abstract int ConcurrencyLimit { get; }

        public abstract TimeSpan Interval { get; }
    }
}
