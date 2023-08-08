namespace Services.SubModules.LogicLayers.Helpers
{
    /// <summary>
    /// This class, named EnumHelper, provides utility methods for working with enums.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// This method takes a collection of integer IDs and returns the corresponding enum values of type TEnum.
        /// It ensures that only valid enum values are returned based on the provided integer IDs.
        /// </summary>
        /// <typeparam name="TEnum">The enum type for which to retrieve values.</typeparam>
        /// <param name="ids">The collection of integer IDs representing enum values.</param>
        /// <returns>An enumerable collection of enum values of type TEnum.</returns>
        public static IEnumerable<TEnum> GetEnumValues<TEnum>(IEnumerable<int> ids) where TEnum : Enum
        {
            // Use LINQ to filter the provided IDs and select only those that are defined in the enum type TEnum.
            var result = ids.Where(id => Enum.IsDefined(typeof(TEnum), id))
                            .Select(id => (TEnum)Enum.ToObject(typeof(TEnum), id));

            // Return the resulting collection of enum values.
            return result;
        }
    }

}
