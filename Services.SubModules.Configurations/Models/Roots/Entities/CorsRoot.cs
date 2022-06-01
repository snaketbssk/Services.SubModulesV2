namespace Services.SubModules.Configurations.Models.Roots.Entities
{
    public class OriginsCor
    {
        public string UrlCors { get; set; }
    }

    public class CorsRoot
    {
        public List<OriginsCor> OriginsCors { get; set; }
    }
}
