using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class CreatedAtOrderByRequest<T> : BaseOrderByRequest<CreatedAtTable<T>>
    {
        public OrderByRequest CreatedAt { get; set; }
        public override IQueryable<CreatedAtTable<T>> OrderBy(IQueryable<CreatedAtTable<T>> result)
        {
            switch (CreatedAt)
            {
                case OrderByRequest.Asc:
                    result = result.OrderBy(x => x.CreatedAt);
                    break;
                case OrderByRequest.Desc:
                    result = result.OrderByDescending(x => x.CreatedAt);
                    break;
            }
            return result;
        }
    }
}
