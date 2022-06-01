namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public abstract class Mapping<T> : IMapping<T> where T : class
    {
        public Mapping()
        {
        }
        public abstract T Map();
        public abstract T Update(T result);
    }
}
