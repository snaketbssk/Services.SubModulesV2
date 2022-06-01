namespace Services.SubModules.DataLayers.Models.Tables
{
    public interface IBaseTable<T>
    {
        T Id { get; set; }
    }
}
