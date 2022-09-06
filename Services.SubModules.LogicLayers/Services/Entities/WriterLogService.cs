using Services.SubModules.Configurations.Constants;
using Services.SubModules.LogicLayers.Helpers;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class WriterLogService : IWriterLogService
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
        private async Task CreateLogFileAsync(string path, CancellationToken cancellationToken = default)
        {
            if (!File.Exists(path))
            {
                await File.WriteAllTextAsync(path, string.Empty, cancellationToken);
            }
        }
        public async Task<bool> WriteLogFileAsync(DateTime timestamp, string text, CancellationToken cancellationToken = default)
        {
            try
            {
                var directory = GetPathDirectory(timestamp, text);
                CreateDirectory(directory);
                var file = GetPathFile(directory);
                await CreateLogFileAsync(file, cancellationToken);
                await File.AppendAllTextAsync(file, text, cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
