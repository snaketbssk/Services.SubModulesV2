using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class CurrenciesCommonGrpcRequestMapping : Mapping<CurrenciesCommonGrpcRequest>
    {
        public CurrenciesCommonGrpcRequestMapping()
        {
        }

        public override CurrenciesCommonGrpcRequest Map()
        {
            var result = new CurrenciesCommonGrpcRequest()
            {
            };

            return result;
        }

        public override CurrenciesCommonGrpcRequest Update(CurrenciesCommonGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
