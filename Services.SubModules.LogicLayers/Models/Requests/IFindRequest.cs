namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IFindRequest<T> where T : class
    {
        IQueryable<T> Find(IQueryable<T> result);
    }
}
