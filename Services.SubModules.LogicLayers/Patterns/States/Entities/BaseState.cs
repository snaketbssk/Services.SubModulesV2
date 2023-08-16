namespace Services.SubModules.LogicLayers.Patterns.States.Entities
{
    /// <summary>
    /// Represents a base class for states in a state pattern.
    /// </summary>
    /// <typeparam name="T">The type of context that this state works with.</typeparam>
    public abstract class BaseState<T> : IState<T>
    {
        /// <summary>
        /// The context associated with the state.
        /// </summary>
        protected T _context;

        /// <summary>
        /// Sets the context associated with this state.
        /// </summary>
        /// <param name="context">The context to set.</param>
        public void SetContext(T context)
        {
            _context = context;
        }
    }
}
