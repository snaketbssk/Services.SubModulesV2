namespace Services.SubModules.LogicLayers.Services
{
    public interface ILocalizationService
    {
        string GetCulture();
        string GetText(string path);
        string SetCulture(string rawCulture);
    }
}
