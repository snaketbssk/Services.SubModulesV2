namespace Services.SubModules.LogicLayers.Models.Requests
{
    public interface IBaseIdRequest<T>
    {
        T? Id { get; set; }

        string ToIdString();
    }
}
