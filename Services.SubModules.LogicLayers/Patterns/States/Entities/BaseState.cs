using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Patterns.States.Entities
{
    public abstract class BaseState : IState
    {
        protected IContextState _context;

        public void SetContext(IContextState context)
        {
            _context = context;
        }
    }
}
