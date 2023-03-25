namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    public class SecurityEnvironmentRoot
    {
        public string? TOKEN { get; set; }
        public string? ISSUER { get; set; }
        public string? AUDIENCE { get; set; }
        public int? EXPIRE { get; set; }
    }
}
