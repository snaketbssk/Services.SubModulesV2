namespace Services.SubModules.LogicLayers.Models.Mappings
{
    public interface IMapping<T> where T : class
    {
        T Map();
        T Update(T result);
    }
}
