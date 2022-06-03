namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IExceptionResponse
    {
        string Timestamp { get; set; }
        string Guid { get; set; }

        string ToString();
    }
}
