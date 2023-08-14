namespace Services.SubModules.LogicLayers.MassTransits.Consumers
{
    /// <summary>
    /// Represents the configuration for a MassTransit consumer.
    /// </summary>
    public interface IConfigurationConsumer : IBaseMassTransit
    {
        /// <summary>
        /// Gets the type of the consumer.
        /// </summary>
        Type TypeConsumer { get; }

        /// <summary>
        /// Gets the number of times a message should be retried in case of failure.
        /// </summary>
        int? RetryCount { get; }

        /// <summary>
        /// Gets the number of messages that can be pre-fetched.
        /// </summary>
        int? PrefetchCount { get; }

        /// <summary>
        /// Gets the maximum number of messages that can be processed concurrently.
        /// </summary>
        int? ConcurrencyLimit { get; }

        /// <summary>
        /// Gets the time interval for retrying messages.
        /// </summary>
        TimeSpan? Interval { get; }
    }
}
