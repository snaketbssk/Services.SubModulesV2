using MassTransit;
using Services.SubModules.LogicLayers.MassTransits.Entities;

namespace Services.SubModules.LogicLayers.MassTransits.Consumers.Entities
{
    public abstract class BaseConfigurationConsumer<TMessage, TConsumer>
        : BaseMassTransit<TMessage>, IConfigurationConsumer
        where TMessage : class
        where TConsumer : IConsumer<TMessage>
    {
        public Type TypeConsumer => typeof(TConsumer);

        public abstract int? RetryCount { get; }

        public abstract int? PrefetchCount { get; }

        public abstract int? ConcurrencyLimit { get; }

        public abstract TimeSpan? Interval { get; }

        public override string NameAssembly => TypeConsumer?.Assembly?.GetName()?.Name ?? string.Empty;

        public override string NameConsumer => TypeConsumer?.Name ?? string.Empty;
    }
}
