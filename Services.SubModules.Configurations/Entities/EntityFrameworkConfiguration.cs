using Microsoft.Extensions.Configuration;
using Services.SubModules.Configurations.Constants;
using Services.SubModules.Configurations.Helpers;

namespace Services.SubModules.Configurations.Entities
{
    /// <summary>
    /// EntityFramework класс конфигурации
    /// </summary>
    /// <typeparam name="T">Json класс конфигурации</typeparam>
    public class EntityFrameworkConfiguration<T> : SingletonConfiguration<EntityFrameworkConfiguration<T>>
        where T : class, new()
    {
        /// <summary>
        /// Название файла конфигурации
        /// </summary>
        protected override string _nameFile => ConfigurationConstant.ENTITY_FRAMEFORK_FILE;

        /// <summary>
        /// Json класс конфигурации
        /// </summary>
        public T Root { get; private set; }

        /// <summary>
        /// Загрузка файла конфигурации
        /// </summary>
        /// <param name="root"></param>
        protected override void Load(IConfigurationRoot root)
        {
            Root = new T();
            root.Bind(Root);
        }

        /// <summary>
        /// Получить путь к файлу
        /// </summary>
        /// <param name="nameFile"></param>
        /// <returns></returns>
        protected override string GetPath(string nameFile)
        {
            var result = ConfigurationHelper.GetPath(_nameFile);
            return result;
        }
    }
}
