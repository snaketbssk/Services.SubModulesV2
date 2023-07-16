using Services.SubModules.DataLayers.Models.Tables;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface ILanguageResponse : IBaseTable<Guid>
    {
        string? Name { get; set; }
    }
}
