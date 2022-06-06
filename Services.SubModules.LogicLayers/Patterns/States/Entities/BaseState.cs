namespace Services.SubModules.LogicLayers.Patterns.States.Entities
{
    public abstract class BaseState<T> : IState where T : IContextState
    {
        protected IContextState _context;

        public void SetContext(IContextState context)
        {
            _context = context;
        }
    }
}
