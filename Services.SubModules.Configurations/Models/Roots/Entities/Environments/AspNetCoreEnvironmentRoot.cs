namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    /// <summary>
    /// Represents the root model for ASP.NET Core environment configuration.
    /// </summary>
    public class AspNetCoreEnvironmentRoot
    {
        /// <summary>
        /// Gets or sets the environment name.
        /// </summary>
        public string? ENVIRONMENT { get; set; }

        /// <summary>
        /// Gets or sets the assembly information.
        /// </summary>
        public string? ASSEMBLY { get; set; }

        /// <summary>
        /// Gets or sets the ID information.
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// Gets or sets the session information.
        /// </summary>
        public string? SESSION { get; set; }

        /// <summary>
        /// Gets or sets the domain information.
        /// </summary>
        public string? DOMAIN { get; set; }
    }
}
