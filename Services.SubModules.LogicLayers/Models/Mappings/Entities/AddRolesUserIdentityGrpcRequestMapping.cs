using Google.Protobuf;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class AddRolesUserIdentityGrpcRequestMapping : Mapping<AddRolesUserIdentityGrpcRequest>
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public AddRolesUserIdentityGrpcRequestMapping(Guid id, IEnumerable<string> roles)
        {
            Id = id;
            Roles = roles;
        }
        public override AddRolesUserIdentityGrpcRequest Map()
        {
            var result = new AddRolesUserIdentityGrpcRequest();
            result.Id = ByteString.CopyFrom(Id.ToByteArray());
            result.Roles.AddRange(Roles);

            return result;
        }

        public override AddRolesUserIdentityGrpcRequest Update(AddRolesUserIdentityGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
