using Services.SubModules.Configurations.Constants;

namespace Services.SubModules.Configurations.Helpers
{
    /// <summary>
    /// Provides helper methods for configuration related tasks.
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Gets the path to a configuration file based on the provided filename.
        /// </summary>
        /// <param name="nameFile">The name of the configuration file.</param>
        /// <returns>The full path to the configuration file.</returns>
        public static string GetPath(string nameFile)
        {
            // Combine the app settings directory path with the provided filename.
            var result = Path.Combine(ConfigurationConstant.APPSETTINGS_DIRECTORY, nameFile);
            return result;
        }
    }
}
