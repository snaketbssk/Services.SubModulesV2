namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    public abstract class CreatedAtTable<T> : BaseTable<T>, ICreatedAtTable
    {
        public DateTime? CreatedAt { get; set; }
    }
}
