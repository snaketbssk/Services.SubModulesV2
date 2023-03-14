using Services.SubModules.LogicLayers.Models.Exceptions;
using System.Text;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class LogResponse : ILogResponse
    {
        public string Service { get; set; }
        public string Timestamp { get; set; }
        public StatusServiceException Status { get; set; }
        public string Guid { get; set; }
        public string MessageException { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string StackTrace { get; set; }

        public LogResponse(string service, DateTime timestamp, StatusServiceException status, Guid guid, string messageException, string path, string method, string stackTrace)
        {
            Service = service;
            Timestamp = timestamp.ToString();
            Guid = guid.ToString();
            MessageException = messageException;
            Path = path;
            Method = method;
            StackTrace = stackTrace;
            Status = status;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine();
            // Service
            result.Append("Service: ");
            result.AppendLine(Service);
            // Timestamp
            result.Append("Timestamp: ");
            result.AppendLine(Timestamp);
            // Status
            result.Append("Status: ");
            result.AppendLine($"{Status}");
            // Guid
            result.Append("Guid: ");
            result.AppendLine(Guid);
            // Method
            result.Append("Method: ");
            result.AppendLine(Method);
            // Path
            result.Append("Path: ");
            result.AppendLine(Path);
            // Message
            result.Append("Message: ");
            result.AppendLine(MessageException);
            // StackTrace
            result.Append("StackTrace: ");
            result.AppendLine(StackTrace);
            // Result
            return result.ToString();
        }
    }
}
