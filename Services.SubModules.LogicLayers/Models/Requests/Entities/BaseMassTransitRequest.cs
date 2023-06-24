namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public abstract class BaseMassTransitRequest<T> : IMassTransitRequest<T>
    {
        public List<T> Values { get; set; }

        public BaseMassTransitRequest()
        {
            Values = new List<T>();
        }
    }
}
