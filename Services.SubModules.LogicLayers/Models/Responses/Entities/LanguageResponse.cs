using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class LanguageResponse : BaseTable<Guid>, ILanguageResponse
    {
        public string? Name { get; set; }
    }
}
