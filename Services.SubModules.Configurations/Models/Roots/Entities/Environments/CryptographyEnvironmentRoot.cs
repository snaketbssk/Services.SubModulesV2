namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    /// <summary>
    /// Represents the root model for cryptography-related environment configuration.
    /// </summary>
    public class CryptographyEnvironmentRoot
    {
        /// <summary>
        /// Gets or sets the cryptography key.
        /// </summary>
        public string? KEY { get; set; }

        /// <summary>
        /// Gets or sets the cryptography initialization vector (IV).
        /// </summary>
        public string? IV { get; set; }
    }
}
