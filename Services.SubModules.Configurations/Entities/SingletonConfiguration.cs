namespace Services.SubModules.Configurations.Entities
{
    public abstract class SingletonConfiguration<T> : BaseConfiguration
        where T : BaseConfiguration, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static T Instance = new T();
    }
}
