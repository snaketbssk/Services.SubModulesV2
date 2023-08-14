using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request for ordering based on creation date.
    /// </summary>
    /// <typeparam name="T">The type of entity being ordered.</typeparam>
    public class CreatedAtOrderByRequest<T> : BaseOrderByRequest<CreatedAtTable<T>>
    {
        /// <summary>
        /// Gets or sets the order direction for creation date.
        /// </summary>
        public OrderByRequest CreatedAt { get; set; }

        /// <summary>
        /// Orders the result based on the creation date.
        /// </summary>
        /// <param name="result">The queryable result to be ordered.</param>
        /// <returns>The ordered queryable result.</returns>
        public override IQueryable<CreatedAtTable<T>> OrderBy(IQueryable<CreatedAtTable<T>> result)
        {
            switch (CreatedAt)
            {
                case OrderByRequest.Asc:
                    result = result.OrderBy(x => x.CreatedAt);
                    break;
                case OrderByRequest.Desc:
                    result = result.OrderByDescending(x => x.CreatedAt);
                    break;
            }
            return result;
        }
    }
}
