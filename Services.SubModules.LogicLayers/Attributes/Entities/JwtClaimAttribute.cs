using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Attributes.Entities
{
    public class JwtClaimAttribute : NameAttribute
    {
        public JwtClaimAttribute(string name) : base(name)
        {
        }
    }
}
