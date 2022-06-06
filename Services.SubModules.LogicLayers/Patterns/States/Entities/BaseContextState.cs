﻿namespace Services.SubModules.LogicLayers.Patterns.States.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseContextState<T> : IContextState where T : IState
    {
        /// <summary>
        /// 
        /// </summary>
        protected IState _state;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public BaseContextState(IState state)
        {
            TransitionTo(state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void TransitionTo(IState state)
        {
            _state = state;
            _state.SetContext(this);
        }
    }
}
