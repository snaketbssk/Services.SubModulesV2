namespace Services.SubModules.LogicLayers.Patterns.States.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseState<T> : IState<T>
    {
        /// <summary>
        /// 
        /// </summary>
        protected T _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void SetContext(T context)
        {
            _context = context;
        }
    }
}
