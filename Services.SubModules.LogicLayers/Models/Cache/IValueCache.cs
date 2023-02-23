using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IValueCache<TValue>
    {
        TValue Value { get; set; }
        bool IsSuccessful { get; set; }
    }
}
