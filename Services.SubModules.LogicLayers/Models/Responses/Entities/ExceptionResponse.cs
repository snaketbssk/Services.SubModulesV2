using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class ExceptionResponse : IExceptionResponse
    {
        public string Timestamp { get; set; }
        public string Guid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExceptionResponse()
        {

        }

        public ExceptionResponse(DateTime timestamp, Guid guid)
        {
            Timestamp = timestamp.ToString();
            Guid = guid.ToString();
        }

        public override string ToString()
        {
            var result = JsonSerializer.Serialize(this);
            return result;
        }
    }
}
