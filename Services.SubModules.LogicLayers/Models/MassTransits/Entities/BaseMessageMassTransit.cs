using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.MassTransits.Entities
{
    public abstract class BaseMessageMassTransit<T> : IMessageMassTransit<T>
    {
        public List<T> Values { get; set; }

        public BaseMessageMassTransit()
        {
            Values = new List<T>();
        }
    }
}
