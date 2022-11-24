namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class IdsRequest : IIdsRequest
    {
        public List<IdRequest> Ids { get; set; }

        public IdsRequest()
        {
            //
        }

        public IdsRequest(IdRequest id)
        {
            Ids = new List<IdRequest>() { id };
        }

        public IdsRequest(IEnumerable<IdRequest> ids)
        {
            Ids = new List<IdRequest>(ids);
        }
    }
}
