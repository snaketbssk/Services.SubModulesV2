using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class CreateReferralReferralsGrpcRequestMapping : Mapping<CreateReferralReferralsGrpcRequest>
    {
        public Guid IdUser { get; set; }
        public string TokenReferral { get; set; }

        public CreateReferralReferralsGrpcRequestMapping(Guid idUser, string tokenReferral)
        {
            IdUser = idUser;
            TokenReferral = tokenReferral;
        }

        public override CreateReferralReferralsGrpcRequest Map()
        {
            var result = new CreateReferralReferralsGrpcRequest
            {
                IdUser = IdUser.ToString(),
                TokenReferral = TokenReferral
            };
            return result;
        }

        public override CreateReferralReferralsGrpcRequest Update(CreateReferralReferralsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
