using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.MassTransits
{
    public interface IMessageMassTransit<T>
    {
        List<T> Values { get; set; }
    }
}
