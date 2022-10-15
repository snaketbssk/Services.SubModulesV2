using Services.SubModules.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class AuthenticationIdentityGrpcRequestMapping : Mapping<AuthenticationIdentityGrpcRequest>
    {
        public string Token { get; set; }

        public AuthenticationIdentityGrpcRequestMapping(string token)
        {
            Token = token;
        }

        public override AuthenticationIdentityGrpcRequest Map()
        {
            var result = new AuthenticationIdentityGrpcRequest()
            {
                Token = Token
            };

            return result;
        }

        public override AuthenticationIdentityGrpcRequest Update(AuthenticationIdentityGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
