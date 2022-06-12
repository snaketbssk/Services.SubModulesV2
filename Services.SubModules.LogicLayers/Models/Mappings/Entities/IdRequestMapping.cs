using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Requests.Entities;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class IdRequestMapping : Mapping<IIdRequest>
    {
        public Guid Id { get; set; }

        public IdRequestMapping(Guid id)
        {
            Id = id;
        }

        public IdRequestMapping(UserIdentityGrpcRequest request)
        {
            Id = new Guid(request.Id.ToByteArray());
        }

        public override IIdRequest Map()
        {
            var result = new IdRequest
            {
                Id = Id
            };
            return result;
        }

        public override IIdRequest Update(IIdRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
