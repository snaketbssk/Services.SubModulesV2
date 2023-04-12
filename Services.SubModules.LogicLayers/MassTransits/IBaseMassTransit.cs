namespace Services.SubModules.LogicLayers.MassTransits
{
    public interface IBaseMassTransit
    {
        Type TypeConsumer { get; }

        Type TypeMessage { get; }

        string QueuePath { get; }
    }
}
