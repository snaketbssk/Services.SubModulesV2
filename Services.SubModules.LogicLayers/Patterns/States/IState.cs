using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Patterns.States
{
    public interface IState
    {
        void SetContext(IContextState context);
    }
}
