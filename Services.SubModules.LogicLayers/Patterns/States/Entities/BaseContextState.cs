namespace Services.SubModules.LogicLayers.Patterns.States.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseContextState<T> where T : IState<BaseContextState<T>>
    {
        /// <summary>
        /// 
        /// </summary>
        protected T _state;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public BaseContextState(T state)
        {
            TransitionTo(state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void TransitionTo(T state)
        {
            _state = state;
            _state.SetContext(this);
        }
    }
}
