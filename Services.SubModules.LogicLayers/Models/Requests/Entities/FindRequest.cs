namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public abstract class FindRequest<T> : IFindRequest<T> where T : class
    {
        public abstract IQueryable<T> Find(IQueryable<T> result);
    }
}
