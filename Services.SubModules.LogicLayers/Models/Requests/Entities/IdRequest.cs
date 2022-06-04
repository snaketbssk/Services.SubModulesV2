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
        public override string ToIdString()
        {
            var result = Id.ToString();
            return result;
        }
    }
}
