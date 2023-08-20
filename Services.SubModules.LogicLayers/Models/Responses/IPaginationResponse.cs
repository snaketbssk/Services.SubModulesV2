using AutoMapper;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for pagination response models.
    /// </summary>
    /// <typeparam name="T">The type of values in the pagination response.</typeparam>
    public interface IPaginationResponse<T>
    {
        /// <summary>
        /// Gets the total count of items.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets the list of values in the pagination response.
        /// </summary>
        List<T> Values { get; }

        /// <summary>
        /// Converts the pagination response to a different type using AutoMapper.
        /// </summary>
        /// <typeparam name="TClass">The target type to convert to.</typeparam>
        /// <param name="mapper">The AutoMapper instance used for conversion.</param>
        /// <returns>A new pagination response of the target type.</returns>
        IPaginationResponse<TClass> Convert<TClass>(IMapper mapper);
    }
}
