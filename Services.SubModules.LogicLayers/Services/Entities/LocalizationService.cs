using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class LocalizationService : ILocalizationService
    {
        private readonly Dictionary<string, IConfigurationRoot> _localization;
        private readonly ILogger<LocalizationService> _logger;
        public LocalizationService(ILogger<LocalizationService> logger)
        {
            _logger = logger;
            _localization = new Dictionary<string, IConfigurationRoot>();
            Load();
        }

        private void Load()
        {
            var root = LocalizationConfiguration<LocalizationRoot>.Instance.Root;
            foreach (var cultureLocalization in root.CultureLocalizations)
            {
                var configurationRoot = GetRoot(cultureLocalization.NameCultureLocalization);
                _localization.Add(cultureLocalization.NameCultureLocalization, configurationRoot);
            }
        }

        private IConfigurationRoot GetRoot(string culture)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var pathFile = Path.Combine("Resources", $"localization.{culture}.json");
            configurationBuilder.AddJsonFile(pathFile, false);
            var result = configurationBuilder.Build();
            return result;
        }

        public string GetString(string path)
        {
            var root = LocalizationConfiguration<LocalizationRoot>.Instance.Root;
            var result = GetString(path, root.DefaultLocalization);
            return result;
        }

        public string GetString(string path, string culture)
        {
            var result = _localization[culture][path];
            return result;
        }
    }
}
