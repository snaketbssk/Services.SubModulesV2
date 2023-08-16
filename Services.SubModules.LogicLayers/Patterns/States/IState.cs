namespace Services.SubModules.LogicLayers.Patterns.States
{
    /// <summary>
    /// Represents an interface for states in a state pattern.
    /// </summary>
    /// <typeparam name="T">The type of context that this state works with.</typeparam>
    public interface IState<T>
    {
        /// <summary>
        /// Sets the context associated with this state.
        /// </summary>
        /// <param name="context">The context to set.</param>
        void SetContext(T context);
    }
}
