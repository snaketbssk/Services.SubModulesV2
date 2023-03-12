using Microsoft.Extensions.Logging;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IActionLoggerService
    {
        void ActionSuccess<T>(ILogger<T> _logger, string subject, string content);
    }
}
