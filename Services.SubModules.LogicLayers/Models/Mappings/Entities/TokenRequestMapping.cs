using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Requests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class TokenRequestMapping : Mapping<ITokenRequest>
    {
        public string Token { get; set; }

        public TokenRequestMapping(string token)
        {
            Token = token;
        }

        public override ITokenRequest Map()
        {
            var result = new TokenRequest
            {
                Token = Token
            };
            return result;
        }

        public override ITokenRequest Update(ITokenRequest result)
        {
            throw new NotImplementedException();
        }
    }
}
