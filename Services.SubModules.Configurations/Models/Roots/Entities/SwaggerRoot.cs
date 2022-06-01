namespace Services.SubModules.Configurations.Models.Roots.Entities
{
    public class SwaggerRoot
    {
        public bool IsActiveSwagger { get; set; }
        public bool IsAuthenticationSwagger { get; set; }
        public string NameFile { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
