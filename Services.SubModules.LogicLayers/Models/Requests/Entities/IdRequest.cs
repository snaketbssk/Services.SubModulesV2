using Google.Protobuf;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class IdRequest : BaseIdRequest<Guid>, IIdRequest
    {
        public IdRequest() : base()
        {

        }
        public IdRequest(Guid id) : base(id)
        {

        }
        public IdRequest(byte[] bytes) : base(new Guid(bytes))
        {

        }
        public IdRequest(ByteString bytes) : base(new Guid(bytes.ToByteArray()))
        {

        }
        public override string ToIdString()
        {
            var result = Id.ToString();
            return result;
        }
    }
}
