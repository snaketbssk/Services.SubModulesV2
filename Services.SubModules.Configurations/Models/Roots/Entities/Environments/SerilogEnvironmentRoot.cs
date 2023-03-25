namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    public class SerilogEnvironmentRoot
    {
        public int? CONSOLE_LEVEL { get; set; }

        public string? FILE_PATH { get; set; }

        public int? FILE_LEVEL { get; set; }

        public string? SEQ_HOST { get; set; }

        public string? SEQ_API_KEY { get; set; }

        public int? SEQ_LEVEL { get; set; }
    }
}
