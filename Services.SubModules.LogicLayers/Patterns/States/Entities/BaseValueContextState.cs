namespace Services.SubModules.LogicLayers.Patterns.States.Entities
{
    public abstract class BaseValueContextState<TValue> : BaseContextState<IState>
    {
        private protected readonly TValue _value;
        protected BaseValueContextState(TValue value, IState state) : base(state)
        {
            _value = value;
        }
    }
}
