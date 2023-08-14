namespace Services.SubModules.LogicLayers.Models.Requests
{
    /// <summary>
    /// Represents an interface for request classes with a Guid-based ID.
    /// </summary>
    public interface IIdRequest : IBaseIdRequest<Guid>
    {
        // This interface inherits properties and methods from IBaseIdRequest<Guid>
    }
}
