using Services.SubModules.LogicLayers.Models.Exceptions;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IExceptionResponse
    {
        string Timestamp { get; set; }
        string Guid { get; set; }
        public StatusServiceException Status { get; set; }

        string ToString();
    }
}
