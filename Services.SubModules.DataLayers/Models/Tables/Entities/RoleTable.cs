using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    public class RoleTable : IdentityRole<Guid>, ICreatedAtTable
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override string NormalizedName 
        {
            get => base.NormalizedName;
            set => base.NormalizedName = value;
        }

        public virtual DateTime? CreatedAt { get; set; }
    }
}
