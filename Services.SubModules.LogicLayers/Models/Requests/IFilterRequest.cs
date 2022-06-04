namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IFilterRequest<T> where T : class
    {
        IQueryable<T> Find(IQueryable<T> result);
    }
}
