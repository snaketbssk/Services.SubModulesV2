using Microsoft.EntityFrameworkCore;
using Services.SubModules.DataLayers.Constants;
using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.DataLayers.Helpers
{
    public static class ModelBuilderHelper
    {
        public static void OnModelCreating<TTable, TId>(this ModelBuilder modelBuilder)
            where TTable : CreatedAtTable<TId>
        {
            modelBuilder.Entity<TTable>().Property(v => v.CreatedAt).HasDefaultValueSql(ContextConstant.GET_UTC_DATE);
        }
    }
}
