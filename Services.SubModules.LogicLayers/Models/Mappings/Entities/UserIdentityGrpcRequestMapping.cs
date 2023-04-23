using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class UserIdentityGrpcRequestMapping : Mapping<IdGrpcModel>
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
        public override IdGrpcModel Map()
        {
            var result = new IdGrpcModel
            {
                Id = Id.ToString()
            };
            return result;
        }

        public override IdGrpcModel Update(IdGrpcModel result)
        {
            throw new NotImplementedException();
        }
    }
}
