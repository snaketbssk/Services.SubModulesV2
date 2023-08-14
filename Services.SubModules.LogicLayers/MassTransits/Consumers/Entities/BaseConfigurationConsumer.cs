using MassTransit;
using Services.SubModules.LogicLayers.MassTransits.Entities;
using System;

namespace Services.SubModules.LogicLayers.MassTransits.Consumers.Entities
{
    /// <summary>
    /// Abstract base class for MassTransit configuration consumers that handle messages of a specific type.
    /// </summary>
    /// <typeparam name="TMessage">The type of message that the consumer handles.</typeparam>
    /// <typeparam name="TConsumer">The concrete consumer type that implements <see cref="IConsumer{TMessage}"/>.</typeparam>
    public abstract class BaseConfigurationConsumer<TMessage, TConsumer>
        : BaseMassTransit<TMessage>, IConfigurationConsumer
        where TMessage : class
        where TConsumer : IConsumer<TMessage>
    {
        /// <summary>
        /// Gets the type of the consumer.
        /// </summary>
        public Type TypeConsumer => typeof(TConsumer);

        /// <summary>
        /// Gets the number of times a message should be retried in case of failure.
        /// </summary>
        public abstract int? RetryCount { get; }

        /// <summary>
        /// Gets the number of messages that can be pre-fetched.
        /// </summary>
        public abstract int? PrefetchCount { get; }

        /// <summary>
        /// Gets the maximum number of messages that can be processed concurrently.
        /// </summary>
        public abstract int? ConcurrencyLimit { get; }

        /// <summary>
        /// Gets the time interval for retrying messages.
        /// </summary>
        public abstract TimeSpan? Interval { get; }

        /// <summary>
        /// Gets the name of the assembly containing the consumer type.
        /// </summary>
        public override string NameAssembly => TypeConsumer?.Assembly?.GetName()?.Name ?? string.Empty;

        /// <summary>
        /// Gets the name of the consumer type.
        /// </summary>
        public override string NameConsumer => TypeConsumer?.Name ?? string.Empty;
    }
}
