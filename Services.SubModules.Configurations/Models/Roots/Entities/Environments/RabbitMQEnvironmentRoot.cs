namespace Services.SubModules.Configurations.Models.Roots.Entities.Environments
{
    public class RabbitMqEnvironmentRoot
    {
        public string TYPE { get; set; }
        public string HOST { get; set; }
        public string PORT_5672 { get; set; }
        public string PORT_15672 { get; set; }
        public string DEFAULT_USER { get; set; }
        public string DEFAULT_PASS { get; set; }
    }
}
