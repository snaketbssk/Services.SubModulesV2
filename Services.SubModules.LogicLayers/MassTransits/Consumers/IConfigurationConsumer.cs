namespace Services.SubModules.LogicLayers.MassTransits.Consumers
{
    public interface IConfigurationConsumer : IBaseMassTransit
    {
        int? RetryCount { get; }

        int? PrefetchCount { get; }

        int? ConcurrencyLimit { get; }

        TimeSpan? Interval { get; }
    }
}
