namespace Services.SubModules.Configurations.Entities.Environments
{
    public abstract class SingletonEnvironmentConfiguration<T> : BaseEnvironmentConfiguration
        where T : BaseEnvironmentConfiguration, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static T Instance = new();
    }
}
