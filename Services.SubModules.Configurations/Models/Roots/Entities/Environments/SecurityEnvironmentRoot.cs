namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    /// <summary>
    /// Represents a root entity for security environment configuration.
    /// </summary>
    public class SecurityEnvironmentRoot
    {
        /// <summary>
        /// Gets or sets the security token for authentication and authorization.
        /// </summary>
        public string? TOKEN { get; set; }

        /// <summary>
        /// Gets or sets the issuer of the security token.
        /// </summary>
        public string? ISSUER { get; set; }

        /// <summary>
        /// Gets or sets the audience for which the security token is intended.
        /// </summary>
        public string? AUDIENCE { get; set; }

        /// <summary>
        /// Gets or sets the expiration duration in minutes for the security token.
        /// </summary>
        public int? EXPIRE { get; set; }
    }
}
