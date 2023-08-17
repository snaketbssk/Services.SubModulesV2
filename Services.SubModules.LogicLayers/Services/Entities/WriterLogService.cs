using Services.SubModules.Configurations.Constants;
using Services.SubModules.LogicLayers.Helpers;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Service responsible for writing log information to files.
    /// </summary>
    public class WriterLogService : IWriterLogService
    {
        // Constructor is missing in the provided code, consider adding it if needed.

        /// <summary>
        /// Gets the path of the directory where log files are stored based on the timestamp and text.
        /// </summary>
        /// <param name="timestamp">The timestamp indicating when the log entry was created.</param>
        /// <param name="text">The text content of the log entry.</param>
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

        /// <summary>
        /// Gets the path of the log file within the specified directory.
        /// </summary>
        /// <param name="pathDirectory">The path of the directory where the log file should be created.</param>
        private string GetPathFile(string pathDirectory)
        {
            var result = Path.Combine(pathDirectory, ConfigurationConstant.EXCEPTION_FILE);
            return result;
        }

        /// <summary>
        /// Creates a directory at the specified path if it doesn't exist.
        /// </summary>
        /// <param name="path">The path of the directory to be created.</param>
        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Creates a new log file at the specified path if it doesn't exist.
        /// </summary>
        /// <param name="path">The path of the log file to be created.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        private async Task CreateLogFileAsync(string path, CancellationToken cancellationToken = default)
        {
            if (!File.Exists(path))
            {
                await File.WriteAllTextAsync(path, string.Empty, cancellationToken);
            }
        }

        /// <summary>
        /// Writes log information to a log file asynchronously.
        /// </summary>
        /// <param name="timestamp">The timestamp indicating when the log entry was created.</param>
        /// <param name="text">The text content of the log entry.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A boolean indicating whether the log entry was successfully written.</returns>
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
