namespace Services.SubModules.LogicLayers.Attributes.Entities
{
    /// <summary>
    /// Represents an abstract base class for custom attributes with a name.
    /// </summary>
    public abstract class NameAttribute : Attribute
    {
        /// <summary>
        /// The name associated with the attribute.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="NameAttribute"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name associated with the attribute.</param>
        public NameAttribute(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
