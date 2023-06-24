namespace Services.SubModules.LogicLayers.MassTransits.Consumers
{
    public interface IConfigurationConsumer : IBaseMassTransit
    {
        Type TypeConsumer { get; }

        int? RetryCount { get; }

        int? PrefetchCount { get; }

        int? ConcurrencyLimit { get; }

        TimeSpan? Interval { get; }
    }
}
