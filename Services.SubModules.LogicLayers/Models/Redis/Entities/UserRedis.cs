using Services.SubModules.DataLayers.Models.Tables.Entities;
using Services.SubModules.LogicLayers.Models.Authentication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Redis.Entities
{
    public class UserRedis : BaseTable<Guid>, IUserRedis
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
        public string PhoneNumber { get; set; }
        public bool ConfirmedPhoneNumber { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public List<ClaimRedis> Claims { get; set; }
    }
}
