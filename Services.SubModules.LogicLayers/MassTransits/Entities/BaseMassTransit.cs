namespace Services.SubModules.LogicLayers.MassTransits.Entities
{
    public abstract class BaseMassTransit<TMessage> : IBaseMassTransit
    {
        public abstract string NameAssembly { get; }

        public abstract string NameConsumer { get; }

        public Type TypeMessage => typeof(TMessage);

        public virtual string? Prefix { get; }

        public virtual string? Postfix { get; }

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
