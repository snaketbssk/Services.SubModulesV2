namespace Services.SubModules.LogicLayers.Patterns.States
{
    public interface IState
    {
        void SetContext(IContextState context);
    }
}
