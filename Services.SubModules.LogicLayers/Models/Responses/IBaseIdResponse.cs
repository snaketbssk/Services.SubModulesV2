namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IBaseIdResponse<T>
    {
        T? Id { get; set; }

        string ToIdString();
    }
}
