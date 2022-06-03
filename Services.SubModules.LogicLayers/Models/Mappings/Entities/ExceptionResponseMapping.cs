using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class ExceptionResponseMapping : Mapping<IExceptionResponse>
    {
        public DateTime Timestamp { get; set; }
        public Guid Guid { get; set; }
        public ExceptionResponseMapping(DateTime timestamp, Guid guid)
        {
            Timestamp = timestamp;
            Guid = guid;
        }
        public override IExceptionResponse Map()
        {
            var result = new ExceptionResponse
            {
                Timestamp = Timestamp.ToString(),
                Guid = Guid.ToString()
            };
            return result;
        }

        public override IExceptionResponse Update(IExceptionResponse result)
        {
            throw new NotImplementedException();
        }
    }
}
