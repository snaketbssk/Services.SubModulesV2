namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    /// <summary>
    /// Represents a root entity for RabbitMQ environment configuration.
    /// </summary>
    public class RabbitMqEnvironmentRoot
    {
        /// <summary>
        /// Gets or sets the type of the RabbitMQ environment.
        /// </summary>
        public string TYPE { get; set; }

        /// <summary>
        /// Gets or sets the host address of the RabbitMQ server.
        /// </summary>
        public string HOST { get; set; }

        /// <summary>
        /// Gets or sets the port number for the standard AMQP protocol (5672) of RabbitMQ.
        /// </summary>
        public string PORT_5672 { get; set; }

        /// <summary>
        /// Gets or sets the port number for the RabbitMQ management UI (15672).
        /// </summary>
        public string PORT_15672 { get; set; }

        /// <summary>
        /// Gets or sets the default username for accessing RabbitMQ.
        /// </summary>
        public string DEFAULT_USER { get; set; }

        /// <summary>
        /// Gets or sets the default password for accessing RabbitMQ.
        /// </summary>
        public string DEFAULT_PASS { get; set; }
    }
}
