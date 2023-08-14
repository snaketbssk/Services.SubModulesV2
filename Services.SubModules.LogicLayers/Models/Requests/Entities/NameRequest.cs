namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request for a name.
    /// </summary>
    public class NameRequest : INameRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameRequest"/> class with default values.
        /// </summary>
        public NameRequest()
        {
            // Default constructor with no parameters.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameRequest"/> class with a provided name.
        /// </summary>
        /// <param name="name">The name to set.</param>
        public NameRequest(string name)
        {
            Name = name;
        }
    }
}
