namespace Services.SubModules.LogicLayers.MassTransits.Entities
{
    /// <summary>
    /// Abstract base class for MassTransit entities related to message handling.
    /// </summary>
    /// <typeparam name="TMessage">The type of message that the entity relates to.</typeparam>
    public abstract class BaseMassTransit<TMessage> : IBaseMassTransit
    {
        /// <summary>
        /// Gets the name of the assembly containing the message consumer type.
        /// </summary>
        public abstract string NameAssembly { get; }

        /// <summary>
        /// Gets the name of the consumer type.
        /// </summary>
        public abstract string NameConsumer { get; }

        /// <summary>
        /// Gets the type of the message associated with the entity.
        /// </summary>
        public Type TypeMessage => typeof(TMessage);

        /// <summary>
        /// Gets the prefix used in the queue path, if applicable.
        /// </summary>
        public virtual string? Prefix { get; }

        /// <summary>
        /// Gets the postfix used in the queue path, if applicable.
        /// </summary>
        public virtual string? Postfix { get; }

        /// <summary>
        /// Gets the full queue path based on the provided prefix, assembly name, consumer name, and postfix.
        /// </summary>
        public string QueuePath
        {
            get
            {
                var values = new List<string>();

                if (!string.IsNullOrWhiteSpace(Prefix))
                    values.Add(Prefix);
                if (!string.IsNullOrWhiteSpace(NameAssembly))
                    values.Add(NameAssembly);
                if (!string.IsNullOrWhiteSpace(NameConsumer))
                    values.Add(NameConsumer);
                if (!string.IsNullOrWhiteSpace(Postfix))
                    values.Add(Postfix);

                var separator = '_';
                var result = string.Join(separator, values);

                return result;
            }
        }
    }
}
