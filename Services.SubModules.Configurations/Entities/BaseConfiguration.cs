using Microsoft.Extensions.Configuration;
using Services.SubModules.Configurations.Helpers;

namespace Services.SubModules.Configurations.Entities
{
    /// <summary>
    /// Базовый класс конфигурации
    /// </summary>
    public abstract class BaseConfiguration
    {
        /// <summary>
        /// Название файла конфигурации
        /// </summary>
        protected abstract string _nameFile { get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        protected internal BaseConfiguration()
        {
            Load();
        }
        /// <summary>
        /// Загрузка файла конфигурации
        /// </summary>
        public void Load()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var pathFile = ConfigurationHelper.GetPath(_nameFile);
            configurationBuilder.AddJsonFile(pathFile, false);
            var root = configurationBuilder.Build();
            Load(root);
        }
        /// <summary>
        /// Загрузка файла конфигурации
        /// </summary>
        /// <param name="root"></param>
        protected abstract void Load(IConfigurationRoot root);
    }
}
