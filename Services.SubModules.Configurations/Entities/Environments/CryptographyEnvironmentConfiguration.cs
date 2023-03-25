using Microsoft.Extensions.Configuration;
using Services.SubModules.Configurations.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.Configurations.Entities.Environments
{
    public class CryptographyEnvironmentConfiguration<T> : SingletonEnvironmentConfiguration<CryptographyEnvironmentConfiguration<T>>
        where T : class, new()
    {
        protected override string Prefix => ConfigurationConstant.CRYPTOGRAPHY_ENVIRONMENT;

        public T GetRoot()
        {
            var result = new T();
            ConfigurationRoot.Bind(result);

            return result;
        }
    }
}
