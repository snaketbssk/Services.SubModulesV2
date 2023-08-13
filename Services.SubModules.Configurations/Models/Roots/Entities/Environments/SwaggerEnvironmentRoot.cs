namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    /// <summary>
    /// Represents a root entity for Swagger environment configuration.
    /// </summary>
    public class SwaggerEnvironmentRoot
    {
        /// <summary>
        /// Gets or sets a value indicating whether Swagger is active.
        /// </summary>
        public bool? ACTIVE { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Swagger requires authentication.
        /// </summary>
        public bool? AUTHENTICATION { get; set; }
    }
}
