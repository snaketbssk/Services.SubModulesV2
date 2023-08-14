namespace Services.SubModules.LogicLayers.Models.Mappings
{
    /// <summary>
    /// Represents the contract for mapping and updating objects.
    /// </summary>
    /// <typeparam name="T">The type of object being mapped.</typeparam>
    public interface IMapping<T> where T : class
    {
        /// <summary>
        /// Maps the properties of the current instance to an instance of type T.
        /// </summary>
        /// <returns>The mapped instance of type T.</returns>
        T Map();

        /// <summary>
        /// Updates an existing instance of type T with the properties of the current instance.
        /// </summary>
        /// <param name="result">The existing instance of type T to be updated.</param>
        /// <returns>The updated instance of type T.</returns>
        T Update(T result);
    }
}
