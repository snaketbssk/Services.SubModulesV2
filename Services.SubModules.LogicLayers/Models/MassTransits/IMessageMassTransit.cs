using System.Collections.Generic;

namespace Services.SubModules.LogicLayers.Models.MassTransits
{
    /// <summary>
    /// Represents a MassTransit message with a list of values.
    /// </summary>
    /// <typeparam name="T">The type of values in the message.</typeparam>
    public interface IMessageMassTransit<T>
    {
        /// <summary>
        /// Gets or sets the list of values in the message.
        /// </summary>
        List<T> Values { get; set; }
    }
}
