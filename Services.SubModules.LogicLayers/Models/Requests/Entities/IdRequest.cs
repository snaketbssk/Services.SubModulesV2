namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class IdRequest : BaseIdRequest<Guid>, IIdRequest
    {
        public override string ToIdString()
        {
            var result = Id.ToString();
            return result;
        }
    }
}
