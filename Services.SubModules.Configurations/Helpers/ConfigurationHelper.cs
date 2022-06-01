using Services.SubModules.Configurations.Constants;

namespace Services.SubModules.Configurations.Helpers
{
    /// <summary>
    /// Хелпер конфигурации
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Получить путь к файлу
        /// </summary>
        /// <param name="nameFile">Название файла конфигурации</param>
        /// <returns></returns>
        public static string GetPath(string nameFile)
        {
            var result = Path.Combine(ConfigurationConstant.APPSETTINGS_DIRECTORY, nameFile);
            return result;
        }
    }
}
