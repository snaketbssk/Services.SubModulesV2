namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    /// <summary>
    /// Represents a root entity for gRPC environment configuration.
    /// </summary>
    public class GrpcEnvironmentRoot
    {
        /// <summary>
        /// Gets or sets the security token for gRPC authentication.
        /// </summary>
        public string? TOKEN { get; set; }

        /// <summary>
        /// Gets or sets the timeout duration in milliseconds for gRPC calls.
        /// </summary>
        public int? TIMEOUT { get; set; }

        /// <summary>
        /// Gets or sets the maximum size in bytes for received messages.
        /// </summary>
        public int? RECEIVE_SIZE { get; set; }

        /// <summary>
        /// Gets or sets the maximum size in bytes for sent messages.
        /// </summary>
        public int? SEND_SIZE { get; set; }

        /// <summary>
        /// Gets or sets the host address for the identity service.
        /// </summary>
        public string? IDENTITY_HOST { get; set; }

        /// <summary>
        /// Gets or sets the host address for the telegram service.
        /// </summary>
        public string? TELEGRAM_HOST { get; set; }

        /// <summary>
        /// Gets or sets the host address for the realtors service.
        /// </summary>
        public string? REALTORS_HOST { get; set; }

        /// <summary>
        /// Gets or sets the host address for the storage service.
        /// </summary>
        public string? STORAGE_HOST { get; set; }

        /// <summary>
        /// Gets or sets the host address for the mailer service.
        /// </summary>
        public string? MAILER_HOST { get; set; }

        /// <summary>
        /// Gets or sets the host address for the notifications service.
        /// </summary>
        public string? NOTIFICATIONS_HOST { get; set; }

        /// <summary>
        /// Gets or sets the host address for the wallets service.
        /// </summary>
        public string? WALLETS_HOST { get; set; }

        /// <summary>
        /// Gets or sets the host address for the common service.
        /// </summary>
        public string? COMMON_HOST { get; set; }

        /// <summary>
        /// Gets or sets the host address for the referrals service.
        /// </summary>
        public string? REFERRALS_HOST { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GrpcEnvironmentRoot"/> class.
        /// </summary>
        public GrpcEnvironmentRoot()
        {
            // Default constructor, no additional initialization logic required.
        }
    }
}
