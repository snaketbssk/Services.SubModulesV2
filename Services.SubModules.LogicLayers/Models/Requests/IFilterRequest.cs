namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for request classes that perform filtering operations on IQueryable data.
    /// </summary>
    /// <typeparam name="T">The type of objects being filtered.</typeparam>
    public interface IFilterRequest<T> where T : class
    {
        /// <summary>
        /// Filters the provided IQueryable based on specific criteria.
        /// </summary>
        /// <param name="result">The IQueryable data to be filtered.</param>
        /// <returns>The filtered IQueryable data.</returns>
        IQueryable<T> Find(IQueryable<T> result);
    }
}
