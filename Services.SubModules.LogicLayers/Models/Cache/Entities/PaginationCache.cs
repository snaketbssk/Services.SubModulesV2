namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class PaginationCache<TValue> : IPaginationCache<TValue>
    {
        public IEnumerable<TValue> Values { get; set; }
        public int TotalCount { get; set; }
        public bool IsSuccessful { get; set; }

        public PaginationCache()
        {

        }

        public PaginationCache(bool isSuccessful, IEnumerable<TValue> values, int totalCount) : this(isSuccessful)
        {
            Values = values;
            TotalCount = totalCount;
        }

        public PaginationCache(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }
    }
}
