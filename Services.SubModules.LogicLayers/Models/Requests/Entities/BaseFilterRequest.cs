namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public abstract class BaseFilterRequest<T> : IFilterRequest<T> where T : class
    {
        public abstract IQueryable<T> Find(IQueryable<T> result);
    }
}
