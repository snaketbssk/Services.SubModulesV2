using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class UserIdentityGrpcRequestMapping : Mapping<UserIdentityGrpcRequest>
    {
        public Guid Id { get; set; }
        public UserIdentityGrpcRequestMapping(Guid id)
        {
            Id = id;
        }
        public UserIdentityGrpcRequestMapping(IIdRequest idRequest)
        {
            Id = idRequest.Id;
        }
        public override UserIdentityGrpcRequest Map()
        {
            var result = new UserIdentityGrpcRequest
            {
                Id = Id.ToString()
            };
            return result;
        }

        public override UserIdentityGrpcRequest Update(UserIdentityGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
