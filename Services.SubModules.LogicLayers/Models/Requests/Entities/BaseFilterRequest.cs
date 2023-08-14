namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a base class for filter requests.
    /// </summary>
    /// <typeparam name="T">The type of entity to filter.</typeparam>
    public abstract class BaseFilterRequest<T> : IFilterRequest<T> where T : class
    {
        /// <summary>
        /// Finds and applies filtering on the provided queryable result.
        /// </summary>
        /// <param name="result">The queryable result to be filtered.</param>
        /// <returns>A queryable result after applying the filter.</returns>
        public abstract IQueryable<T> Find(IQueryable<T> result);
    }
}
