namespace Services.SubModules.LogicLayers.Helpers
{
    /// <summary>
    /// Provides utility methods for working with any objects.
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// Sets values of specified fields from the source object to the target object if they are of the same type.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="target">The target object.</param>
        /// <param name="fields">The list of field names to copy.</param>
        /// <returns>True if any values were copied; otherwise, false.</returns>
        public static bool SetValues(object source, object target, params string[] fields)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(target, nameof(target));
            ArgumentNullException.ThrowIfNull(fields, nameof(fields));

            // Check if the objects are of the same type
            if (source.GetType() != target.GetType())
                throw new ArgumentException("Source and target objects must have the same type.");

            var type = source.GetType();
            var result = false;

            foreach (var field in fields)
            {
                var property = type.GetProperty(field);

                ArgumentNullException.ThrowIfNull(property, nameof(property));

                var valueSource = property.GetValue(source);
                var valueTarget = property.GetValue(target);

                if (!valueSource.Equals(valueTarget))
                {
                    property.SetValue(target, valueSource);
                    result = true;
                }
            }

            return result;
        }
    }
}
