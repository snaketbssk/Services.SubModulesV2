namespace Services.SubModules.LogicLayers.MassTransits.Entities
{
    public class BaseMassTransit<TMessage, TConsumer> : IBaseMassTransit
    {
        public Type TypeConsumer => typeof(TConsumer);

        public Type TypeMessage => typeof(TMessage);

        public virtual string? Prefix { get; }

        public virtual string? Postfix { get; }

        public virtual string QueuePath => string.Format("{0}{1}_{2}_{3}{4}",
                                                          string.IsNullOrWhiteSpace(Prefix) ? "" : $"{Prefix}_",
                                                          typeof(TConsumer).Assembly.GetName().Name,
                                                          TypeConsumer.Name,
                                                          TypeMessage.Name,
                                                          string.IsNullOrWhiteSpace(Postfix) ? "" : $"_{Postfix}");
    }
}
