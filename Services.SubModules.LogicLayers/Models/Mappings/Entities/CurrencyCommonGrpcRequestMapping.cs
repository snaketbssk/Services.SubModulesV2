using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class CurrencyCommonGrpcRequestMapping : Mapping<IdGrpcModel>
    {
        public Guid Id { get; set; }

        public CurrencyCommonGrpcRequestMapping(Guid id)
        {
            Id = id;
        }

        public override IdGrpcModel Map()
        {
            var result = new IdGrpcModel()
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
