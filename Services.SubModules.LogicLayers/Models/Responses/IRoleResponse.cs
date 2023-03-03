using Services.SubModules.DataLayers.Models.Tables;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IRoleResponse : IBaseTable<Guid>
    {
        string Name { get; set; }
    }
}
