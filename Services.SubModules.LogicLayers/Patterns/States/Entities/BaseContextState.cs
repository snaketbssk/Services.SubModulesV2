namespace Services.SubModules.LogicLayers.Patterns.States.Entities
{
    /// <summary>
    /// Represents a base class for context states in a state pattern.
    /// </summary>
    /// <typeparam name="T">The type of state that this context state works with.</typeparam>
    public abstract class BaseContextState<T> where T : IState<BaseContextState<T>>
    {
        /// <summary>
        /// The current state associated with the context.
        /// </summary>
        protected T _state;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContextState{T}"/> class.
        /// </summary>
        /// <param name="state">The initial state of the context.</param>
        public BaseContextState(T state)
        {
            TransitionTo(state);
        }

        /// <summary>
        /// Transitions the context to a new state.
        /// </summary>
        /// <param name="state">The new state to transition to.</param>
        public void TransitionTo(T state)
        {
            _state = state;
            _state.SetContext(this);
        }
    }
}
