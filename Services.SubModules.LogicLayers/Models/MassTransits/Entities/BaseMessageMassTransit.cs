namespace Services.SubModules.LogicLayers.Models.MassTransits.Entities
{
    public abstract class BaseMessageMassTransit<T> : IMessageMassTransit<T>
    {
        public List<T> Values { get; set; }

        public BaseMessageMassTransit()
        {
            Values = new List<T>();
        }
    }
}
