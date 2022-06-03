using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class ExceptionResponse : IExceptionResponse
    {
        public string Timestamp { get; set; }
        public string Guid { get; set; }
        public override string ToString()
        {
            var result = JsonSerializer.Serialize(this);
            return result;
        }
    }
}
