using MassTransit;

namespace Services.SubModules.LogicLayers.Consumers.Entities
{
    public abstract class BaseConfigurationConsumer<TMessage, TConsumer> : IConfigurationConsumer
        where TMessage : class
        where TConsumer : IConsumer<TMessage>
    {
        public Type TypeConsumer => typeof(TConsumer);

        public Type TypeMessage => typeof(TMessage);

        public abstract int RetryCount { get; }

        public abstract int PrefetchCount { get; }

        public abstract int ConcurrencyLimit { get; }

        public abstract TimeSpan Interval { get; }
    }
}
