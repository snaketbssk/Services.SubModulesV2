using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class RoleResponse : BaseTable<Guid>, IRoleResponse
    {
        public string Name { get; set; }

        public RoleResponse()
        {

        }

        public RoleResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
