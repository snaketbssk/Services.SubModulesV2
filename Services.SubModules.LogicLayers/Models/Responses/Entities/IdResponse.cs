using Google.Protobuf;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class IdResponse : BaseIdResponse<Guid>, IIdResponse
    {
        public IdResponse() : base()
        {

        }

        public IdResponse(Guid id) : base(id)
        {

        }

        public IdResponse(byte[] bytes) : base(new Guid(bytes))
        {

        }

        public IdResponse(ByteString bytes) : base(new Guid(bytes.ToByteArray()))
        {

        }

        public IdResponse(string id) : base(Guid.Parse(id))
        {

        }

        public override string ToIdString()
        {
            var result = Id.ToString();
            return result;
        }
    }
}
