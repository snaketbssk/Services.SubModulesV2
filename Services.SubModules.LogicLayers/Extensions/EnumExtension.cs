using System.Reflection;

namespace Services.SubModules.LogicLayers.Extensions
{
    /// <summary>
    /// Extension methods for working with enumerations.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Retrieves the specified attribute from the given enumeration value.
        /// </summary>
        /// <typeparam name="T">The type of attribute to retrieve.</typeparam>
        /// <param name="value">The enumeration value.</param>
        /// <returns>The attribute instance of type T, if found; otherwise, null.</returns>
        public static T GetAttribute<T>(this Enum value)
            where T : Attribute
        {
            var type = value.GetType();  // Get the enumeration type
            var name = Enum.GetName(type, value);  // Get the name of the enumeration value
            return type
                .GetField(name)  // Get the field information for the enumeration value
                .GetCustomAttribute<T>();  // Get the specified attribute of type T
        }
    }
}
