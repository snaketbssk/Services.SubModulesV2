namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public abstract class BaseOrderByRequest<T> : IOrderByRequest<T> where T : class
    {
        public abstract IQueryable<T> OrderBy(IQueryable<T> result);
    }
}
