using Microsoft.Extensions.Configuration;
using Services.SubModules.Configurations.Constants;

namespace Services.SubModules.Configurations.Entities.Environments
{
    public class ServiceEnvironmentConfiguration<T> : SingletonEnvironmentConfiguration<ServiceEnvironmentConfiguration<T>>
        where T : class, new()
    {
        protected override string Prefix => $"{ConfigurationConstant.SERVICE_ENVIRONMENT}{Environment.GetEnvironmentVariable($"{ConfigurationConstant.SERVICE_ENVIRONMENT}NAME")}";

        public T GetRoot()
        {
            var result = new T();
            ConfigurationRoot.Bind(result);

            return result;
        }
    }
}
