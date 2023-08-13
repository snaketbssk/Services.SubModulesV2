namespace Services.SubModules.LogicLayers.Helpers
{
    /// <summary>
    /// Provides utility methods for working with strings.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Removes non-digit characters from a given string, leaving only the digits intact.
        /// </summary>
        /// <param name="value">The input string to process.</param>
        /// <returns>A new string containing only the digits from the input string.</returns>
        public static string ToDigits(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                // Use LINQ to filter and retain only digit characters from the input string.
                var result = new string(value.Where(char.IsDigit).ToArray());
                return result;
            }
            return value;
        }
    }

}
