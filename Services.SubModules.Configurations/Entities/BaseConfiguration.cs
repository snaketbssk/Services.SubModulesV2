using Microsoft.Extensions.Configuration;

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
            var pathFile = GetPath(_nameFile);
            configurationBuilder.AddJsonFile(
                path: pathFile,
                optional: false,
                reloadOnChange: true);
            var root = configurationBuilder.Build();
            Load(root);
        }

        /// <summary>
        /// Загрузка файла конфигурации
        /// </summary>
        /// <param name="root"></param>
        protected abstract void Load(IConfigurationRoot root);

        /// <summary>
        /// Получить путь к файлу
        /// </summary>
        /// <param name="nameFile"></param>
        protected abstract string GetPath(string nameFile);
    }
}
