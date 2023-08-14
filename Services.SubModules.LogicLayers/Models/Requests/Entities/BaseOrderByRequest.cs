namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a base class for requests containing ordering information.
    /// </summary>
    /// <typeparam name="T">The type of entity being ordered.</typeparam>
    public abstract class BaseOrderByRequest<T> : IOrderByRequest<T> where T : class
    {
        /// <summary>
        /// Orders the result based on the specified criteria.
        /// </summary>
        /// <param name="result">The queryable result to be ordered.</param>
        /// <returns>The ordered queryable result.</returns>
        public abstract IQueryable<T> OrderBy(IQueryable<T> result);
    }
}
