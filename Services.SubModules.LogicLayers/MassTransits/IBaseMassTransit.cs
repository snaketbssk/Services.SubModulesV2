namespace Services.SubModules.LogicLayers.MassTransits
{
    public interface IBaseMassTransit
    {
        Type TypeMessage { get; }

        string QueuePath { get; }
    }
}
