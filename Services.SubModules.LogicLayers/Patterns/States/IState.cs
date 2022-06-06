namespace Services.SubModules.LogicLayers.Patterns.States
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IState<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        void SetContext(T context);
    }
}
