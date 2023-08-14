using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request for pagination.
    /// </summary>
    public class PaginationRequest : IPaginationRequest
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        [DefaultValue(1)]
        [Range(1, int.MaxValue)]
        public int NumberPage { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        [DefaultValue(100)]
        [Range(1, int.MaxValue)]
        public int SizePage { get; set; }

        /// <summary>
        /// Gets or sets whether this is the first request.
        /// </summary>
        public bool? FirstRequest { get; set; }

        /// <summary>
        /// Gets or sets whether to order by descending.
        /// </summary>
        public bool? OrderByDescending { get; set; }

        /// <summary>
        /// Gets or sets whether to order randomly.
        /// </summary>
        public bool? RandomOrderBy { get; set; }

        /// <summary>
        /// Gets or sets the property to order by.
        /// </summary>
        public string? PropertyOrderBy { get; set; }

        /// <summary>
        /// Calculates the number of items to skip based on the current page and page size.
        /// </summary>
        /// <returns>The number of items to skip.</returns>
        public int Skip()
        {
            var result = (NumberPage - 1) * SizePage;
            return result;
        }

        /// <summary>
        /// Creates a default pagination request with optional values.
        /// </summary>
        /// <param name="numberPage">The page number.</param>
        /// <param name="sizePage">The number of items per page.</param>
        /// <param name="firstRequest">Whether this is the first request.</param>
        /// <param name="orderByDescending">Whether to order by descending.</param>
        /// <param name="randomOrderBy">Whether to order randomly.</param>
        /// <param name="propertyOrderBy">The property to order by.</param>
        /// <returns>The created pagination request.</returns>
        public static IPaginationRequest CreateDefault(int? numberPage = default,
                                                       int? sizePage = default,
                                                       bool? firstRequest = default,
                                                       bool? orderByDescending = default,
                                                       bool? randomOrderBy = default,
                                                       string? propertyOrderBy = default)
        {
            var request = new PaginationRequest()
            {
                NumberPage = 1,
                SizePage = 1,
                FirstRequest = false,
                OrderByDescending = false,
                RandomOrderBy = false,
                PropertyOrderBy = "Id"
            };

            if (numberPage.HasValue)
                request.NumberPage = numberPage.Value;
            if (sizePage.HasValue)
                request.SizePage = sizePage.Value;
            if (firstRequest.HasValue)
                request.FirstRequest = firstRequest.Value;
            if (orderByDescending.HasValue)
                request.OrderByDescending = orderByDescending.Value;
            if (randomOrderBy.HasValue)
                request.RandomOrderBy = randomOrderBy.Value;
            if (!string.IsNullOrEmpty(propertyOrderBy))
                request.PropertyOrderBy = propertyOrderBy;

            return request;
        }
    }
}
