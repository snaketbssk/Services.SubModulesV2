using Microsoft.EntityFrameworkCore;
using Services.SubModules.DataLayers.Constants;
using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.DataLayers.Helpers
{
    /// <summary>
    /// Helper class containing extension methods for configuring model builders in Entity Framework Core.
    /// </summary>
    public static class ModelBuilderHelper
    {
        /// <summary>
        /// Configures the creation of CreatedAt property with default UTC date value for an entity.
        /// </summary>
        /// <typeparam name="TTable">The type of entity with CreatedAt property.</typeparam>
        /// <typeparam name="TId">The type of the entity's ID.</typeparam>
        /// <param name="modelBuilder">The model builder instance.</param>
        public static void OnModelCreating<TTable, TId>(this ModelBuilder modelBuilder)
            where TTable : CreatedAtTable<TId>
        {
            // Configure the CreatedAt property to have a default value of the current UTC date.
            modelBuilder.Entity<TTable>().Property(v => v.CreatedAt).HasDefaultValueSql(ContextConstant.GET_UTC_DATE);
        }
    }
}
