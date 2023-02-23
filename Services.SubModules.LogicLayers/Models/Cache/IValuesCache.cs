using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IValuesCache<TValues>
    {
        TValues Value { get; set; }
        bool IsSuccessful { get; set; }
    }
}
