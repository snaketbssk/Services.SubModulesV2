namespace Services.SubModules.LogicLayers.Services
{
    public interface IWriterLogService
    {
        Task<bool> WriteLogFileAsync(DateTime timestamp, string text, CancellationToken cancellationToken = default);
    }
}
