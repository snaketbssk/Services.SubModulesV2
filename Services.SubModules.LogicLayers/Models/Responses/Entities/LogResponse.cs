using System.Text;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class LogResponse : ILogResponse
    {
        public string Timestamp { get; set; }
        public string Guid { get; set; }
        public string MessageException { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string StackTrace { get; set; }

        public LogResponse(DateTime timestamp, Guid guid, string messageException, string path, string method, string stackTrace)
        {
            Timestamp = timestamp.ToString();
            Guid = guid.ToString();
            MessageException = messageException;
            Path = path;
            Method = method;
            StackTrace = stackTrace;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine();
            // Timestamp
            result.Append("Timestamp: ");
            result.AppendLine(Timestamp);
            // Guid
            result.Append("Guid: ");
            result.AppendLine(Guid);
            // Message
            result.Append("Message: ");
            result.AppendLine(MessageException);
            // Path
            result.Append("Path: ");
            result.AppendLine(Path);
            // Method
            result.Append("Method: ");
            result.AppendLine(Method);
            // StackTrace
            result.Append("StackTrace: ");
            result.AppendLine(StackTrace);
            // Result
            return result.ToString();
        }
    }
}
