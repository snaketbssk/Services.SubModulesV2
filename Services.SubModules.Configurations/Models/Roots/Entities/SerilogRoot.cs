namespace Services.SubModules.Configurations.Models.Roots.Entities
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Console
    {
        public int LogEventLevel { get; set; }
    }

    public class File
    {
        public string Path { get; set; }
        public int LogEventLevel { get; set; }
    }

    public class SerilogRoot
    {
        public Console Console { get; set; }
        public File File { get; set; }
        public Seq Seq { get; set; }
    }

    public class Seq
    {
        public string Name { get; set; }
        public string ServerUrl { get; set; }
        public string ApiKey { get; set; }
        public int LogEventLevel { get; set; }
    }


}
