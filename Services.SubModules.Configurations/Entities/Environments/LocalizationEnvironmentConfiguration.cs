using Microsoft.Extensions.Configuration;
using Services.SubModules.Configurations.Constants;

namespace Services.SubModules.Configurations.Entities.Environments
{
    public class LocalizationEnvironmentConfiguration<T> : SingletonEnvironmentConfiguration<LocalizationEnvironmentConfiguration<T>>
        where T : class, new()
    {
        protected override string Prefix => ConfigurationConstant.LOCALIZATION_ENVIRONMENT;

        public T GetRoot()
        {
            var result = new T();
            ConfigurationRoot.Bind(result);

            return result;
        }
    }
}
