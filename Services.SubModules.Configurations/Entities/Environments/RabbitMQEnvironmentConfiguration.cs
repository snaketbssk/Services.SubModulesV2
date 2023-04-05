using Microsoft.Extensions.Configuration;
using Services.SubModules.Configurations.Constants;

namespace Services.SubModules.Configurations.Entities.Environments
{
    public class RabbitMQEnvironmentConfiguration<T> : SingletonEnvironmentConfiguration<RabbitMQEnvironmentConfiguration<T>>
        where T : class, new()
    {
        protected override string Prefix => ConfigurationConstant.RABBITMQ_ENVIRONMENT;

        public T GetRoot()
        {
            var result = new T();
            ConfigurationRoot.Bind(result);

            return result;
        }
    }
}
