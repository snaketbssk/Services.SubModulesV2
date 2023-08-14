namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a base abstract class for mapping entities to another type.
    /// </summary>
    /// <typeparam name="T">The type to which the mapping is performed.</typeparam>
    public abstract class Mapping<T> : IMapping<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mapping{T}"/> class.
        /// </summary>
        public Mapping()
        {
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of type T.
        /// </summary>
        /// <returns>The mapped instance of type T.</returns>
        public abstract T Map();

        /// <summary>
        /// Updates an existing instance of type T with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of type T to be updated.</param>
        /// <returns>The updated instance of type T.</returns>
        public abstract T Update(T result);
    }
}
