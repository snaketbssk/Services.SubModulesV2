using Google.Protobuf;
using Services.SubModules.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
