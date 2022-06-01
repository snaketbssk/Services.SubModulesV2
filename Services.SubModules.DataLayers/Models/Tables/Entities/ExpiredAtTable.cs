namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    public abstract class ExpiredAtTable<T> : CreatedAtTable<T>, IExpiredAtTable
    {
        public DateTime? ExpiredAt { get; set; }
    }
}
