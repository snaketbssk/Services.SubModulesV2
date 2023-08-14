using MassTransit;

namespace Services.SubModules.LogicLayers.MassTransits.Buses
{
    /// <summary>
    /// Represents a custom service bus interface that extends the MassTransit IBus interface.
    /// </summary>
    public interface IServiceBus : IBus
    {
        // This interface currently doesn't declare any additional members or methods.
        // It simply inherits the members and methods from the IBus interface.
    }
}
