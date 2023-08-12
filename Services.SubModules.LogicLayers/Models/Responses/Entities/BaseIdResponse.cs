using Services.SubModules.LogicLayers.Models.Requests;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents an abstract base class for response classes with an ID of a generic type.
    /// </summary>
    /// <typeparam name="T">The type of the ID.</typeparam>
    public abstract class BaseIdResponse<T> : IBaseIdRequest<T>
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public T? Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIdResponse{T}"/> class.
        /// </summary>
        public BaseIdResponse()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIdResponse{T}"/> class with the specified ID.
        /// </summary>
        /// <param name="id">The ID value.</param>
        public BaseIdResponse(T id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        /// <summary>
        /// Converts the ID to its string representation.
        /// </summary>
        /// <returns>The string representation of the ID.</returns>
        public abstract string ToIdString();
    }
}
