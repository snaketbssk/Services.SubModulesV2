using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Services.SubModules.DataLayers.Models.Tables.Entities
{
    public class UserTable : IdentityUser<Guid>, ICreatedAtTable
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override string PasswordHash
        {
            get => base.PasswordHash;
            set => base.PasswordHash = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override string SecurityStamp
        {
            get => base.SecurityStamp;
            set => base.SecurityStamp = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override string NormalizedUserName
        {
            get => base.NormalizedUserName;
            set => base.NormalizedUserName = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override string NormalizedEmail
        {
            get => base.NormalizedEmail;
            set => base.NormalizedEmail = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override int AccessFailedCount
        {
            get => base.AccessFailedCount;
            set => base.AccessFailedCount = value;
        }

        public virtual DateTime? CreatedAt { get; set; }
    }
}
