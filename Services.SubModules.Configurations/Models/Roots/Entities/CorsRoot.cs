namespace Services.SubModules.Configurations.Models.Roots.Entities
{
    public class OriginsCors
    {
        public string UrlCors { get; set; }
    }

    public class CorsRoot
    {
        public List<OriginsCors> OriginsCors { get; set; }
        public string BaseAddressCors { get; set; }
    }
}
