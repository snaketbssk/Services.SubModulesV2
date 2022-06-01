using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class RoleIdentityGrpcResponseMapping : Mapping<RoleIdentityGrpcResponse>
    {
        public string Name { get; set; }
        public RoleIdentityGrpcResponseMapping(string name)
        {
            Name = name;
        }
        public override RoleIdentityGrpcResponse Map()
        {
            var result = new RoleIdentityGrpcResponse
            {
                Name = Name
            };
            return result;
        }

        public override RoleIdentityGrpcResponse Update(RoleIdentityGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
