namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IOrderByRequest<T> where T : class
    {
        IQueryable<T> OrderBy(IQueryable<T> result);
    }
}
