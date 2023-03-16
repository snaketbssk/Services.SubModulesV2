namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    public abstract class UpdatedAtTable<T> : CreatedAtTable<T>, IUpdatedAtTable
    {
        public DateTime? UpdatedAt { get; set; }
    }
}
