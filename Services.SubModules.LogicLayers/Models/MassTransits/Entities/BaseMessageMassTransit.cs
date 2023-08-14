using System.Collections.Generic;

namespace Services.SubModules.LogicLayers.Models.MassTransits.Entities
{
    /// <summary>
    /// Represents the base class for MassTransit messages with a list of values.
    /// </summary>
    /// <typeparam name="T">The type of values in the message.</typeparam>
    public abstract class BaseMessageMassTransit<T> : IMessageMassTransit<T>
    {
        /// <summary>
        /// Gets or sets the list of values in the message.
        /// </summary>
        public List<T> Values { get; set; }

        /// <summary>
        /// Initializes a new instance of the BaseMessageMassTransit class.
        /// </summary>
        public BaseMessageMassTransit()
        {
            Values = new List<T>();
        }
    }
}
