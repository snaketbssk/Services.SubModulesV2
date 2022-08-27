namespace Services.SubModules.Configurations.Models.Roots.Entities
{
    public class CultureLocalization
    {
        public string NameCultureLocalization { get; set; }
    }

    public class LocalizationRoot
    {
        public string DefaultLocalization { get; set; }
        public List<CultureLocalization> CultureLocalizations { get; set; }
    }
}
