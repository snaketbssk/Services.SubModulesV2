namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for specifying pagination and ordering options in requests.
    /// </summary>
    public interface IPaginationRequest
    {
        /// <summary>
        /// Gets or sets the page number for pagination.
        /// </summary>
        int NumberPage { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page for pagination.
        /// </summary>
        int SizePage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to order the results in descending order.
        /// </summary>
        bool? OrderByDescending { get; set; }

        /// <summary>
        /// Gets or sets the property by which to order the results.
        /// </summary>
        string? PropertyOrderBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it's the first request.
        /// </summary>
        bool? FirstRequest { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to apply a random order to the results.
        /// </summary>
        bool? RandomOrderBy { get; set; }

        /// <summary>
        /// Computes the number of items to skip based on the pagination settings.
        /// </summary>
        /// <returns>The number of items to skip.</returns>
        int Skip();
    }
}
