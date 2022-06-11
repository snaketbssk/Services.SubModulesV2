namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    public abstract class UpdatedAtTable<T> : BaseTable<T>, IUpdatedAtTable
    {
        public DateTime? UpdatedAt { get; set; }
    }
}
