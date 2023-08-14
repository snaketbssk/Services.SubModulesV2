namespace Services.SubModules.LogicLayers.MassTransits
{
    /// <summary>
    /// Represents a base interface for MassTransit entities providing common properties.
    /// </summary>
    public interface IBaseMassTransit
    {
        /// <summary>
        /// Gets the type of message associated with the MassTransit entity.
        /// </summary>
        Type TypeMessage { get; }

        /// <summary>
        /// Gets the queue path associated with the MassTransit entity.
        /// </summary>
        string QueuePath { get; }
    }
}
