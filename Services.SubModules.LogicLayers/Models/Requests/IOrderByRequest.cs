namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for requests specifying how to order a collection.
    /// </summary>
    /// <typeparam name="T">The type of the items in the collection.</typeparam>
    public interface IOrderByRequest<T> where T : class
    {
        /// <summary>
        /// Orders the provided collection based on a specified criterion.
        /// </summary>
        /// <param name="result">The collection to be ordered.</param>
        /// <returns>An ordered collection.</returns>
        IQueryable<T> OrderBy(IQueryable<T> result);
    }
}
