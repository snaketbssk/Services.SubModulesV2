namespace Services.SubModules.LogicLayers.Services
{
    public interface ILogService
    {
        bool Write(DateTime timestamp, string text);
    }
}
