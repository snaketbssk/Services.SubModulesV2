using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Constants;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using System.Globalization;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for handling localization-related operations.
    /// Implements the <see cref="ILocalizationService"/> interface.
    /// </summary>
    public class LocalizationService : ILocalizationService
    {
        /// <summary>
        /// Stores the localized configurations indexed by culture.
        /// </summary>
        private readonly Dictionary<string, IConfigurationRoot> _localizations;
        private readonly ILogger<LocalizationService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationService"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        public LocalizationService(ILogger<LocalizationService> logger)
        {
            _logger = logger;
            _localizations = new Dictionary<string, IConfigurationRoot>();
            Load();
        }

        /// <summary>
        /// Loads localized configurations from files into memory.
        /// </summary>
        private void Load()
        {
            var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationConstant.LOCALIZATIONS_DIRECTORY);

            if (!Directory.Exists(folderPath))
            {
                return;
            }

            foreach (var file in Directory.GetFiles(folderPath))
            {
                var nameFile = Path.GetFileName(file);
                var splitsNameFile = nameFile.Split('.');
                var configurationRoot = GetRoot(nameFile);
                _localizations.Add(splitsNameFile[1], configurationRoot);
            }
        }

        /// <summary>
        /// Gets the configuration root for a specific culture.
        /// </summary>
        /// <param name="culture">The culture for which to retrieve the configuration.</param>
        /// <returns>The configuration root for the specified culture.</returns>
        private IConfigurationRoot GetRoot(string culture)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var pathFile = Path.Combine(ConfigurationConstant.LOCALIZATIONS_DIRECTORY, culture);
            configurationBuilder.AddJsonFile(pathFile, false);
            var result = configurationBuilder.Build();
            return result;
        }

        /// <summary>
        /// Gets the localized text for the specified path using the current culture.
        /// </summary>
        /// <param name="path">The path to the localized text.</param>
        /// <returns>The localized text.</returns>
        public string GetText(string path)
        {
            var result = GetText(path, CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            return result;
        }

        /// <summary>
        /// Gets the localized text for the specified path using the specified culture.
        /// </summary>
        /// <param name="path">The path to the localized text.</param>
        /// <param name="culture">The culture code for the desired language.</param>
        /// <returns>The localized text.</returns>
        public string GetText(string path, string culture)
        {
            var result = _localizations[culture][path];
            return result;
        }

        /// <summary>
        /// Gets the appropriate culture based on the provided culture code.
        /// If culture is null or empty, returns the default culture from the environment configuration.
        /// If the provided culture code is not found, returns the default culture.
        /// </summary>
        /// <param name="culture">The culture code to look up.</param>
        /// <returns>The resolved culture code.</returns>
        private string GetCulture(string culture)
        {
            if (string.IsNullOrWhiteSpace(culture))
            {
                return LocalizationEnvironmentConfiguration<LocalizationEnvironmentRoot>.Instance.GetRoot().DEFAULT;
            }

            if (!_localizations.ContainsKey(culture))
            {
                return LocalizationEnvironmentConfiguration<LocalizationEnvironmentRoot>.Instance.GetRoot().DEFAULT;
            }

            return culture;
        }

        /// <summary>
        /// Gets the culture code for the current thread's culture.
        /// Uses the culture code from the current CultureInfo.
        /// </summary>
        /// <returns>The culture code.</returns>
        public string GetCulture()
        {
            var result = GetCulture(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            return result;
        }

        /// <summary>
        /// Sets the culture for the current thread's culture and UI culture.
        /// Uses the provided raw culture code to set the CultureInfo.
        /// </summary>
        /// <param name="rawCulture">The raw culture code.</param>
        /// <returns>The culture code that was set.</returns>
        public string SetCulture(string rawCulture)
        {
            var result = GetCulture(rawCulture);
            var cultureInfo = new CultureInfo(result);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            return result;
        }
    }
}
