using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class LogResponseMapping : Mapping<ILogResponse>
    {
        public DateTime Timestamp { get; set; }
        public Guid Guid { get; set; }
        public string MessageException { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string StackTrace { get; set; }
        public LogResponseMapping(DateTime timestamp, Guid guid, string messageException, string path, string method, string stackTrace)
        {
            Timestamp = timestamp;
            Guid = guid;
            MessageException = messageException ?? throw new ArgumentNullException(nameof(messageException));
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Method = method ?? throw new ArgumentNullException(nameof(method));
            StackTrace = stackTrace ?? throw new ArgumentNullException(nameof(stackTrace));
        }
        public override ILogResponse Map()
        {
            var result = new LogResponse
            {
                Timestamp = Timestamp.ToString(),
                Guid = Guid.ToString(),
                MessageException = MessageException,
                Path = Path,
                Method = Method,
                StackTrace = StackTrace
            };
            return result;
        }

        public override ILogResponse Update(ILogResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
