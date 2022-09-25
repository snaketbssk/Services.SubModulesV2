using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Constants;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using System.Globalization;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class LocalizationService : ILocalizationService
    {
        private readonly Dictionary<string, IConfigurationRoot> _localizations;
        private readonly ILogger<LocalizationService> _logger;
        public LocalizationService(ILogger<LocalizationService> logger)
        {
            _logger = logger;
            _localizations = new Dictionary<string, IConfigurationRoot>();
            Load();
        }

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

        private IConfigurationRoot GetRoot(string culture)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var pathFile = Path.Combine(ConfigurationConstant.LOCALIZATIONS_DIRECTORY, culture);
            configurationBuilder.AddJsonFile(pathFile, false);
            var result = configurationBuilder.Build();
            return result;
        }

        public string GetText(string path)
        {
            var result = GetText(path, CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            return result;
        }

        public string GetText(string path, string culture)
        {
            var result = _localizations[culture][path];
            return result;
        }

        private string GetCulture(string culture)
        {
            if (string.IsNullOrWhiteSpace(culture))
            {
                return LocalizationConfiguration<LocalizationRoot>.Instance.Root.DefaultCultureLocalization;
            }

            if (!_localizations.ContainsKey(culture))
            {
                return LocalizationConfiguration<LocalizationRoot>.Instance.Root.DefaultCultureLocalization;
            }

            return culture;
        }

        public string GetCulture()
        {
            var result = GetCulture(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            return result;
        }

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
