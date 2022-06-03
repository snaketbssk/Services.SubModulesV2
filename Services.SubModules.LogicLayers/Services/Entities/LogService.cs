using Services.SubModules.Configurations.Constants;
using Services.SubModules.LogicLayers.Helpers;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class LogService : ILogService
    {
        private string GetPathDirectory(DateTime timestamp, string text)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var yearDate = DateTimeHelper.ToYearString(timestamp);
            var monthDate = DateTimeHelper.ToMonthString(timestamp);
            var dayDate = DateTimeHelper.ToDayString(timestamp);
            var result = Path.Combine(
                baseDirectory,
                ConfigurationConstant.LOGS_DIRECTORY,
                yearDate,
                monthDate,
                dayDate);
            return result;
        }
        private string GetPathFile(string pathDirectory)
        {
            var result = Path.Combine(pathDirectory, ConfigurationConstant.EXCEPTION_FILE);
            return result;
        }
        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, string.Empty);
            }
        }
        public bool Write(DateTime timestamp, string text)
        {
            try
            {
                var directory = GetPathDirectory(timestamp, text);
                CreateDirectory(directory);
                var file = GetPathFile(directory);
                CreateFile(file);
                File.AppendAllText(file, text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
