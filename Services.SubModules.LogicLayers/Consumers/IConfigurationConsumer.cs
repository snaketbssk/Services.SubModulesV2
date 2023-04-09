namespace Services.SubModules.LogicLayers.Consumers
{
    public interface IConfigurationConsumer
    {
        Type TypeConsumer { get; }

        Type TypeMessage { get; }

        int RetryCount { get; }

        int PrefetchCount { get; }

        int ConcurrencyLimit { get; }

        TimeSpan Interval { get; }
    }
}
