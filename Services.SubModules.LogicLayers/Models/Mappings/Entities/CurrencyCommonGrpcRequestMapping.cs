using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class CurrencyCommonGrpcRequestMapping : Mapping<CurrencyCommonGrpcRequest>
    {
        public Guid Id { get; set; }

        public CurrencyCommonGrpcRequestMapping(Guid id)
        {
            Id = id;
        }

        public override CurrencyCommonGrpcRequest Map()
        {
            var result = new CurrencyCommonGrpcRequest()
            {
                Id = Id.ToString()
            };

            return result;
        }

        public override CurrencyCommonGrpcRequest Update(CurrencyCommonGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
