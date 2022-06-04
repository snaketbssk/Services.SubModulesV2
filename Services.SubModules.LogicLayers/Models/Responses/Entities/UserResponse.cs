﻿using Services.SubModules.DataLayers.Models.Tables.Entities;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class UserResponse : BaseTable<Guid>, IUserResponse
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool? ConfirmedEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? ConfirmedphoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public List<string> Roles { get; set; }
        public UserResponse()
        {

        }
    }
}