using Services.SubModules.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class ClaimRoleIdentityGrpcResponseMapping : Mapping<ClaimRoleIdentityGrpcResponse>
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public ClaimRoleIdentityGrpcResponseMapping(string type, string value)
        {
            Type = type;
            Value = value;
        }
        public override ClaimRoleIdentityGrpcResponse Map()
        {
            var result = new ClaimRoleIdentityGrpcResponse
            {
                Type = Type,
                Value = Value
            };
            return result;
        }

        public override ClaimRoleIdentityGrpcResponse Update(ClaimRoleIdentityGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
