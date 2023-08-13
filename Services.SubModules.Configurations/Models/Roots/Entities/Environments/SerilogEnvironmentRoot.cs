namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    /// <summary>
    /// Represents a root entity for Serilog environment configuration.
    /// </summary>
    public class SerilogEnvironmentRoot
    {
        /// <summary>
        /// Gets or sets the log level for console output.
        /// </summary>
        public int? CONSOLE_LEVEL { get; set; }

        /// <summary>
        /// Gets or sets the file path for log file output.
        /// </summary>
        public string? FILE_PATH { get; set; }

        /// <summary>
        /// Gets or sets the log level for the log file output.
        /// </summary>
        public int? FILE_LEVEL { get; set; }

        /// <summary>
        /// Gets or sets the host address for the Seq logging server.
        /// </summary>
        public string? SEQ_HOST { get; set; }

        /// <summary>
        /// Gets or sets the API key for authenticating with the Seq server.
        /// </summary>
        public string? SEQ_API_KEY { get; set; }

        /// <summary>
        /// Gets or sets the log level for the Seq server output.
        /// </summary>
        public int? SEQ_LEVEL { get; set; }
    }
}
