﻿using Services.SubModules.DataLayers.Models.Tables;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface IUserResponse : IBaseTable<Guid>
    {
        string? Name { get; set; }
        string? Email { get; set; }
        bool? ConfirmedEmail { get; set; }
        string? PhoneNumber { get; set; }
        bool? ConfirmedphoneNumber { get; set; }
        bool? TwoFactorEnabled { get; set; }
        List<string> Roles { get; set; }
    }
}