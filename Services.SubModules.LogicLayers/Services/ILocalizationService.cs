namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for managing localization operations.
    /// </summary>
    public interface ILocalizationService
    {
        /// <summary>
        /// Gets the current culture.
        /// </summary>
        /// <returns>The current culture as a string.</returns>
        string GetCulture();

        /// <summary>
        /// Gets the localized text for the specified path.
        /// </summary>
        /// <param name="path">The path to the localized text.</param>
        /// <returns>The localized text as a string.</returns>
        string GetText(string path);

        /// <summary>
        /// Sets the current culture using the specified raw culture value.
        /// </summary>
        /// <param name="rawCulture">The raw culture value to set.</param>
        /// <returns>The updated culture as a string.</returns>
        string SetCulture(string rawCulture);
    }
}
