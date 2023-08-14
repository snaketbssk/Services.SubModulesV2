namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a base class for requests containing an ID.
    /// </summary>
    /// <typeparam name="T">The type of the ID.</typeparam>
    public abstract class BaseIdRequest<T> : IBaseIdRequest<T>
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public T? Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIdRequest{T}"/> class.
        /// </summary>
        public BaseIdRequest()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIdRequest{T}"/> class with the specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        public BaseIdRequest(T id)
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
